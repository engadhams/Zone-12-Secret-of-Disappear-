using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    playerMovement plMoveScr;
    AudioSource audSrc;
    // Start is called before the first frame update
    void Start()
    {
        // Set Variables
        plMoveScr = GetComponent<playerMovement>();
        audSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }


    void FootstepSound()
    {
        
    }

}
