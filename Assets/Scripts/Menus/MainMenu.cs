using UnityEngine.SceneManagement;
using UnityEngine;

// Main menu with basic buttons
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        GameManager.instance.isPlaying = true;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("EPIScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
