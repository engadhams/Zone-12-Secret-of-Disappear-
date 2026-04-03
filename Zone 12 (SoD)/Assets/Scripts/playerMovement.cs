using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float mouseSens = 2;
    public float horiz;
    public float vert;
    public float mouseX;
    public float mouseY;
    public GameObject player;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void Look()
    {
        mouseX = Input.GetAxis("Mouse Y")*mouseSens;
        mouseY = Input.GetAxis("Mouse X")*mouseSens;

        Quaternion rotValue = Quaternion.Euler(mouseX,mouseY,0);
        
        transform.rotation = rotValue;
    }
}
