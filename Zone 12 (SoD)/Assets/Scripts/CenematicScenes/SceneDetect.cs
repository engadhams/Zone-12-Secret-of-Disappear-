using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDetect : MonoBehaviour
{
    public Cinema cen;
    public string targetScene;

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            if(targetScene == "GetMission")
            {
                cen.ActivateScene1();
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
