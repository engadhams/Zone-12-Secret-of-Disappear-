using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    float hMove;
    float vMove;
    public PlayerMovement pMove;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");

        /*//Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.speed = 1.5f;
        }
        else
        {
            anim.speed = 1f;
        }*/

        // Animations MoveForward
        if(pMove.canMove)
        {
            if (vMove == 0 && hMove == 0)
            {
                anim.SetBool("Walk", false);
            }
            else
            {
                anim.SetBool("Walk", true);
            }
        }
        


        
    }
}
