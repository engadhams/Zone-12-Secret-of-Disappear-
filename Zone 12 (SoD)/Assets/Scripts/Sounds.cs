using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource src;

    public AudioClip fireClip;
    public AudioClip reloadClip;
    public AudioClip camTrans;
    public AudioClip BoatMotor;
    public AudioClip radio;
    public bool isPlaying;
    

    public void fireSound()
    {
        src.clip = fireClip;
        src.Play();
    }
    public void reloadSound()
    {
        src.clip = reloadClip;
        src.Play();
    }
    /*public void CenCamSound()
    {
        src.clip = camTrans;
        src.Play();
    }*/
    public void BoatMotorSound()
    {
        isPlaying =true;
        src.clip = BoatMotor;
        src.loop = true;
        src.Play();
    }
    public void radioNoise()
    {
        isPlaying =true;
        src.clip = radio;
        src.loop = false;
        src.pitch = 1.5f;
        src.volume = 0.6f;
        src.Play();

        
    }
    public void StopSounds()
    {
        src.Stop();
    }
    
}
