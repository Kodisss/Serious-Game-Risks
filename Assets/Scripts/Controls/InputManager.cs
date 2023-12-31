using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton management because we only ever need one instance
    private static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }

    private PlayerControls playerControls;

    private void Awake()
    {
        // singleton management here
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    // this is useful for a pause or game loss
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }


    //Using Unity's new input system to get the player movement and interactions
    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PressedEKeyThisFrame()
    {
        return playerControls.Player.Interact.triggered;
    }
}
