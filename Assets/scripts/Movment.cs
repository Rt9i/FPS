using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    private float xRotation = 0f;
    [SerializeField] private InputAction movment;
    [SerializeField] private InputAction jumpAction;
    [SerializeField] private CharacterController controller;
    [SerializeField] Transform PlayerCamera;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float SprintSpeed = 10f;
    private bool jumpPressed = false;
    private Vector3 velocity;
    private Vector2 moveInput;

    void OnEnable()
    {
        movment.Enable();
        jumpAction.Enable();
        jumpAction.performed += ctx => jumpPressed = true;
        jumpAction.canceled += ctx => jumpPressed = false;
    }

    void OnDisable()
    {
        movment.Disable();
        jumpAction.performed -= ctx => jumpPressed = true;
        jumpAction.canceled -= ctx => jumpPressed = false;
        jumpAction.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        ApplyGravity();
        HandleRotation(mouseY, mouseX);
        HandleMovement();

        HandleJump();

    }

    private void HandleMovement()
    {
        moveInput = movment.ReadValue<Vector2>();

        Vector3 forward = PlayerCamera.forward;
        Vector3 right = PlayerCamera.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = right * moveInput.x + forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime);

    }

    void HandleJump()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && jumpPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void HandleRotation(float mouseY, float mouseX)
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        PlayerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }
}
