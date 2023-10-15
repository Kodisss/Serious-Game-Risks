using UnityEngine;

public class Interactor : MonoBehaviour
{
    // interaction physics utilities
    [SerializeField] private float interactionRange = 3.0f;

    // interaction data collection
    Interactable interactable;
    private InputManager inputManager;
    private HUDController hudController;

    // get the inputmanager instance
    private void Start()
    {
        inputManager = InputManager.Instance;
        hudController = HUDController.Instance;
    }

    // take the first detected collider out of the three possible and interact sith it if E key is pressed
    private void Update()
    {
        CheckInteractions();
        DisplayPrompt();
        if (interactable != null && inputManager.PressedEKeyThisFrame()) interactable.Interact(this);
    }

    private void CheckInteractions()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if(Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.collider.tag == "Interactable") //if you hit an interactable object
            {
                interactable = hit.collider.GetComponent<Interactable>();
            }
        }
        else
        {
            interactable = null;
        }
    }

    private void DisplayPrompt()
    {
        if(interactable != null)
        {
            hudController.EnableInteractionText(interactable.GetPrompt());
        }
        else
        {
            hudController.DisableInteractionText();
        }
    }
}
