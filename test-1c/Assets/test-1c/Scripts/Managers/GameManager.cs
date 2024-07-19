using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Lose and Win screen GO
    [SerializeField] private GameObject winScreen, loseScreen;

    #region MonoBehavior Methods

    private void OnEnable()
    {
        GoalManager.OnLose += OnLose;
        GoalManager.OnWin += OnWin;
    }

    private void Start()
    {
        // Start Game
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        GoalManager.OnLose -= OnLose;
        GoalManager.OnWin -= OnWin;
    }

    #endregion

    #region Private Methods

    private void OnWin()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }

    private void OnLose()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
    }

    #endregion
}