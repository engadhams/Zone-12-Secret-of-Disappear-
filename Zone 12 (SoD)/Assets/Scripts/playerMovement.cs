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

    float horiz;
    float vert;
    float mouseX;
    float mouseY;
    float xRot;
    float yRot;

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
    }
    void Move()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector3 move = (vert* transform.forward + transform.right *horiz) *moveSpeed;
        rb.velocity = new Vector3(move.x ,rb.velocity.y, move.z);

        if(vert != 0 || horiz != 0)
        {
            
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 6;
                anim.SetFloat("Speed", 2);
            }
            else
            {
                moveSpeed = 3;
                anim.SetFloat("Speed", 1);
            }

        }
        else
        {
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
}
