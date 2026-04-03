using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public bool canMove=true;
    public bool canRotate=true;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 2f;
    public Camera playerCamera;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if(canRotate)
            Look();
        if(canMove)
            Move();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity* Time.timeScale;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity* Time.timeScale;

        // تحريك الكاميرا على محور X فقط
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // دوران اللاعب على محور Y فقط
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        // حركة اللاعب تعتمد على جسمه وليس الكاميرا
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        move.Normalize(); // مهم لتجنب تسريع الحركة عند التحرك بالقطر (مثلاً W + D)

        // الجاذبية
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f; // صغير لتجنب floating

        // القفز
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = jumpForce;

        velocity.y += gravity * Time.deltaTime;

        // تحريك اللاعب
        controller.Move((move * speed + velocity) * Time.deltaTime);
    }
}