using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float horiz;
    public float vert;
    public GameObject player;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This is a comment
       horiz = Input.GetAxis("Horizontal");
       vert = Input.GetAxis("Vertical");
       Vector3 move = vert* transform.forward + transform.right *horiz;

       rb.velocity = new Vector3(move.x ,rb.velocity.y, move.z);
    }
}
