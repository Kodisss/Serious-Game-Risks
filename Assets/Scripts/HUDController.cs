using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    private static HUDController _instance;

    public static HUDController Instance
    {
        get { return _instance; }
    }

    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private TMP_Text timer;

    private void Awake()
    {
        // singleton management here
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        timer.gameObject.SetActive(false);
    }

    public void UpdateTimer(float timeLeft)
    {
        timer.gameObject.SetActive(true);
        timer.text = timeLeft + " s";
    }

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (E)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
