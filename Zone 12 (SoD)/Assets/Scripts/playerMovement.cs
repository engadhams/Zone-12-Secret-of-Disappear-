using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public GameObject cam;
    public Rigidbody rb;
    public float moveSpeed = 5;
    public float mouseSens = 2;
    public float jumpForce= 2;

    float horiz;
    float vert;
    float mouseX;
    float mouseY;
    float xRot;
    float yRot;

    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Look();
        Jump();
    }
    void Move()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector3 move = (vert* transform.forward + transform.right *horiz) *moveSpeed;
        rb.velocity = new Vector3(move.x ,rb.velocity.y, move.z);

        if(vert != 0 || horiz != 0)
        {
            isMoving = true;
            // Sprint and Walk anims
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 8;
                anim.SetFloat("Speed", 2);
            }
            else
            {
                moveSpeed = 3.5f;
                anim.SetFloat("Speed", 1);
            }

        }
        else
        {
            isMoving = false;
            anim.SetFloat("Speed", 0);
        }
        
    }

    void Look()
    {
        mouseX = Input.GetAxis("Mouse X")*mouseSens;
        mouseY = Input.GetAxis("Mouse Y")*mouseSens;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -80,60);
        
        cam.transform.localRotation = Quaternion.Euler(xRot,0,0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
        }

    }

    public float rayDistance = 1.2f;
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance);
    }
}