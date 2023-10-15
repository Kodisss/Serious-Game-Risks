using UnityEngine;

//Rewriting basic player controller so it works with the new input system
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // basic attribute needed
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;

    //player game variable
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -20.0f; // -20 so the jump feels a little less floaty

    //Instances the controller and Input Manager as well as the Camera transform so when can follow mouse movement
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        //We stop the character from building momentum downward when grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Using the new input system we convert the new Vector 2 in a Vector 3 to be compatible with Unity's built in controller
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        // we take into acount the player's facing direction to move
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f; //because we play with vector there can be some residual value stored in the y value which we don't need

        // Using built in controller we pass or new move vector
        controller.Move(move * Time.deltaTime * playerSpeed);


        //We then check the jump parameter
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
