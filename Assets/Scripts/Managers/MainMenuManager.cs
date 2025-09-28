using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void onNewGame()
    {
        // Load first scene
        SceneManager.LoadScene("Level1");
    }

    public void onLevelMap()
    {
        // Load level map if we ever make it
    }

    public void onExit()
    {
        Application.Quit();
    }
}
