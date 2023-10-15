using UnityEngine;
using UnityEngine.SceneManagement;

public class RisksSceneManager : MonoBehaviour
{
    // instantiate the HUD so we can use it to display time left and EPI collected
    private HUDController hudController;

    // instantiate numbers to make time work
    private float currentTime = 0f;
    [SerializeField] private float gameTime = 180f;

    // get the HUD instance cuz singleton and set the time
    void Start()
    {
        hudController = HUDController.Instance;
        currentTime = gameTime;
    }

    void Update()
    {
        // timer control and display
        currentTime -= 1 * Time.deltaTime;
        hudController.UpdateTimer(currentTime);
        hudController.UpdateRisksCount(GameManager.instance.score);
        CheckForGameEnd();
    }

    //check if time's up or every risks are identified
    private void CheckForGameEnd()
    {
        if(currentTime <= 0f)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else if(GameManager.instance.score == 5)
        {
            GameManager.instance.timeTaken = gameTime - currentTime;
            SceneManager.LoadScene("EndScreen");
        }
    }
}
