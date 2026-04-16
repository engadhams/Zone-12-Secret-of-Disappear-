using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : MonoBehaviour
{
    public GameObject player;
    public Transform Desk;

    [Header("Scene Cameras")]
    public Camera mainCam;
    public Camera cenCam;

    bool playerMoveForward =false;
    bool inCutScene=false;

    playerMovement pM;

    void Start()
    {
        CameraSwitch();
        pM = player.GetComponent<playerMovement>();
    }
    public void ActivateScene1()
    {
        // "GetMission" Scene
        
        pM.isAbletoLook = false;
        pM.isAbletoMove = false;
        player.transform.LookAt(Desk);
        inCutScene = true;
        CameraSwitch();
        playerMoveForward = true;
    }

    void CameraSwitch()
    {
        if(inCutScene)
        {
            mainCam.enabled = false;
            cenCam.enabled = true;
        }
        else if(!inCutScene)
        {
            mainCam.enabled = true;
            cenCam.enabled = false;
        }
    }
    void Update()
    {

        // playerMoveForward Code
        float distance = Vector3.Distance(player.transform.position, Desk.position);

        if(playerMoveForward && distance > 2)
        {
            player.transform.position = player.transform.position + player.transform.forward * 0.04f;
        }
        else if(playerMoveForward && distance < 2)
        {
            pM.isMoving = false;
            pM.anim.SetFloat("Speed", 0);
        }
        //End
    }

}
