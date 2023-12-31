using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    // make a singleton
    private static HUDController _instance;

    public static HUDController Instance
    {
        get { return _instance; }
    }

    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text risksNumber;

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
        timer.gameObject.SetActive(false); // we don't need the timer activated right away, only when the risk scene starts
        risksNumber.gameObject.SetActive(false);
    }


    //Function used to display stuff stored in another object
    public void UpdateTimer(float timeLeft)
    {
        timer.gameObject.SetActive(true);
        timer.text = timeLeft.ToString("0") + "s restantes";
    }

    public void UpdateRisksCount(int value)
    {
        risksNumber.gameObject.SetActive(true);
        risksNumber.text = value + " / 5 risques identifiés";
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
