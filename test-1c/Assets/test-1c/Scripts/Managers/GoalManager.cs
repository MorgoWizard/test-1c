using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private int minEnemiesToKillCount, maxEnemiesToKillCount;
    private int enemiesToKillCount;

    private int currentKilledEnemiesCount;

    private void Awake()
    {
        enemiesToKillCount = Random.Range(minEnemiesToKillCount, maxEnemiesToKillCount + 1);
        Debug.Log($"Goal Manager: current goal {enemiesToKillCount}");
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
    private void Win()
    {
        Debug.Log("Goal Manager: Player win");
    }

    private void CheckWin()
    {
        if (currentKilledEnemiesCount >= enemiesToKillCount) Win();
    }

    private void OnEnemyDeath()
    {
        currentKilledEnemiesCount++;
        CheckWin();
    }

    private void Lose()
    {
        Debug.Log("Goal Manager: Player lose");
    }


}
