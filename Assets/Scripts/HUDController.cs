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
