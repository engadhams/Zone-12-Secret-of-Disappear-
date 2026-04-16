using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public GameObject cam;
    public Rigidbody rb;
    CharacterController controller;
    Vector3 velocity;

    public float moveSpeed = 5;
    public float mouseSens = 2;
    public float jumpForce= 2;

    float gravity=-9.81f;
    float horiz;
    float vert;
    float mouseX;
    float mouseY;
    float xRot;
    float yRot;

    public bool isAbletoMove=true;
    public bool isAbletoLook=true;

    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAbletoMove)
        {
            Move();
            Jump();
        }
        if(isAbletoLook)
        {
            Look();
        }
    }

    //This is a comment
    void Move()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector3 move = (vert* transform.forward + transform.right *horiz);
        move.Normalize();

        controller.Move(move * moveSpeed* Time.deltaTime);

        // الجاذبية
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if((vert != 0 || horiz != 0) && controller.isGrounded)
        {
            isMoving = true;
            // Sprint and Walk anims
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 10;
                anim.SetFloat("Speed", 2);
            }
            else
            {
                moveSpeed = 5f;
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
        

    }
}