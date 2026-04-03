using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDetector : MonoBehaviour
{
    public KeyCode ActionKey;
    public int targetScene;
    public Cinema cen;
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(cen.scenesCompleted +1 == targetScene)
            {
                cen.curScene = targetScene;
                cen.goForScene();
                GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }
}
