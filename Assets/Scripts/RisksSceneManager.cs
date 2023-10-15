using UnityEngine;
using UnityEngine.SceneManagement;

public class RisksSceneManager : MonoBehaviour
{
    private HUDController hudController;

    private float currentTime = 0f;
    [SerializeField] private float gameTime = 180f;

    // Start is called before the first frame update
    void Start()
    {
        hudController = HUDController.Instance;
        currentTime = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        hudController.UpdateTimer(currentTime);
        CheckForGameEnd();
    }

    private void CheckForGameEnd()
    {
        if(currentTime <= 0f)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else if(GameManager.instance.score == 5)
        {
            GameManager.instance.timeTaken = currentTime;
            SceneManager.LoadScene("EndScreen");
        }
    }
}
