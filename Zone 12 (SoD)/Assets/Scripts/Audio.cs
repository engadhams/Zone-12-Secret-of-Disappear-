using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    playerMovement plMoveScr;
    AudioSource audSrc;
    [Header("Clips")]
    public AudioClip footstep;

    // Start is called before the first frame update
    void Start()
    {
        // Set Variables
        plMoveScr = GetComponent<playerMovement>();
        audSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(plMoveScr.isMoving)
        {
            FootstepSound();
        }
        else
        {
            StopSounds();
        }
        
    }


    void FootstepSound()
    {
        audSrc.clip = footstep;
        audSrc.Play();
        audSrc.loop = true;
        
    }

    void StopSounds()
    {
        audSrc.Stop();
    }

}
