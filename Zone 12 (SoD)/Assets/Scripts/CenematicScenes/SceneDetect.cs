using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDetect : MonoBehaviour
{
    public Cinema cen;
    public string sceneSel;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("SceneActivator") && sceneSel=="GetMission")
        {
            cen.ActivateScene1();
            hit.gameObject.GetComponent<BoxCollider>().enabled =false;
        }
    }
}
