using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player object.
    [SerializeField] private float sensitivity = 0.04f; // Mouse look sensitivity.
    [SerializeField] private float smoothing = 2.0f; // Mouse smoothing.

    private Vector2 smoothMouse;
    private Vector2 mouseLook;

    private InputManager inputManager;

    private void Start()
    {
        // Lock and hide the cursor.
        inputManager = InputManager.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Read the mouse input using the new input system.
        Vector2 mouseDelta = inputManager.GetMouseDelta();

        // Apply smoothing to the mouse input.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1f / smoothing);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1f / smoothing);

        // Adjust the mouse look based on the smoothed input.
        mouseLook += smoothMouse;

        // Clamp the vertical rotation to prevent looking upside down.
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        // Rotate the camera and player based on the mouse input.
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
