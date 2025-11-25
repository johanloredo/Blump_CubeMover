using UnityEngine;

public class Mover : MonoBehaviour
{
    private PlayerControls playerControls;

    private Vector2 leftJoystick;
    bool leftStickMoving;

    [SerializeField]
    private Transform playerJoystick;
    [SerializeField]
    private Transform playerArrows;

    private float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartInput();
    }

    void StartInput()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        // Joystick
        playerControls.Mover.LeftJoystick.performed += ctx =>
        {
            leftStickMoving = true;

            leftJoystick = ctx.ReadValue<Vector2>();
            Debug.Log(leftJoystick);
        };
        playerControls.Mover.LeftJoystick.canceled += ctx =>
        {
            leftStickMoving = false;
            leftJoystick = Vector2.zero;
        };

        // Up
        playerControls.Mover.Up.performed += ctx =>
        {
            Debug.Log("Up performed");
            playerArrows.position = new Vector3(playerArrows.position.x,
                                                playerArrows.position.y,
                                                playerArrows.position.z + speed);
        };
        playerControls.Mover.Up.canceled += ctx =>
        {
            Debug.Log("Up canceled");
        };
        // Down
        playerControls.Mover.Down.performed += ctx =>
        {
            Debug.Log("Down performed");
            playerArrows.position = new Vector3(playerArrows.position.x,
                                                playerArrows.position.y,
                                                playerArrows.position.z - speed);
        };
        playerControls.Mover.Down.canceled += ctx =>
        {
            Debug.Log("Down canceled");
        };
        // Left
        playerControls.Mover.Left.performed += ctx =>
        {
            Debug.Log("Left performed");
            playerArrows.position = new Vector3(playerArrows.position.x - speed,
                                                playerArrows.position.y,
                                                playerArrows.position.z);
        };
        playerControls.Mover.Left.canceled += ctx =>
        {
            Debug.Log("Left canceled");
        };
        // Right
        playerControls.Mover.Right.performed += ctx =>
        {
            Debug.Log("Right performed");
            playerArrows.position = new Vector3(playerArrows.position.x + speed,
                                                playerArrows.position.y,
                                                playerArrows.position.z);
        };
        playerControls.Mover.Right.canceled += ctx =>
        {
            Debug.Log("Right canceled");
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (leftStickMoving == true)
        {
            LeftJoystickMovement();
        }
    }

    void LeftJoystickMovement()
    {
        playerJoystick.position = new Vector3(playerJoystick.position.x + leftJoystick.x,
                                              playerJoystick.position.y,
                                              playerJoystick.position.z + leftJoystick.y);
    }
}
