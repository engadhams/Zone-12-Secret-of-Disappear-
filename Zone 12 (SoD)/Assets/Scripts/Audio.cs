using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public bool isPlaying=false;
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
        if(!isPlaying)
        {
            isPlaying = true;
            audSrc.clip = footstep;
            audSrc.loop = true;
            audSrc.Play();
        }
        
    }

    void StopSounds()
    {
        isPlaying = false;
        audSrc.Stop();
    }

}
