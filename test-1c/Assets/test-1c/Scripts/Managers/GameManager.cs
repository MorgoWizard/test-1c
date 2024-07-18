using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen, loseScreen;

    private void Start()
    {
        // Start Game
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        GoalManager.OnLose += OnLose;
        GoalManager.OnWin += OnWin;
    }

    private void OnDisable()
    {
        GoalManager.OnLose -= OnLose;
        GoalManager.OnWin -= OnWin;
    }

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
}
