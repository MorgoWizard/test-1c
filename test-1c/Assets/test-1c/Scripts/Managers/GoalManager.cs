using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoalManager : MonoBehaviour
{
    // Min and Max enemies to kill count. Used to calculate current game goal
    [SerializeField] private int minEnemiesToKillCount, maxEnemiesToKillCount;

    /// <summary>
    /// Goal
    /// </summary>
    private int _enemiesToKillCount;

    private int _currentKilledEnemiesCount;

    public static event Action OnWin;
    public static event Action OnLose;

    #region MonoBehavior Methods

    private void Awake()
    {
        _enemiesToKillCount = Random.Range(minEnemiesToKillCount, maxEnemiesToKillCount + 1);
        Debug.Log($"Goal Manager: current goal {_enemiesToKillCount}");
    }

    private void OnEnable()
    {
        CharacterHealth.OnDeath += Lose;
        EnemyHealth.OnDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        CharacterHealth.OnDeath -= Lose;
        EnemyHealth.OnDeath -= OnEnemyDeath;
    }

    #endregion

    #region Private Methods

    private void Win()
    {
        Debug.Log("Goal Manager: Player win");
        OnWin?.Invoke();
    }

    private void CheckWin()
    {
        if (_currentKilledEnemiesCount >= _enemiesToKillCount) Win();
    }

    private void OnEnemyDeath()
    {
        _currentKilledEnemiesCount++;
        CheckWin();
    }

    private void Lose()
    {
        Debug.Log("Goal Manager: Player lose");
        OnLose?.Invoke();
    }

    #endregion
}