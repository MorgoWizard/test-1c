using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Loads scene by name
    /// </summary>
    /// <param name="sceneName">Scene's to load name</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Reloads current scene
    /// </summary>
    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
