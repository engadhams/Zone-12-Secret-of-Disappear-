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
        mainCam.enabled = true;
        cenCam.enabled = false;
        pM = player.GetComponent<playerMovement>();
    }

    public void ActivateScene1()
    {
        // "GetMission" Scene
        pM.isAbletoLook = false;
        pM.isAbletoMove = false;
        pM.anim.SetFloat("Speed", 1);

        Vector3 dskPos =  new Vector3(Desk.position.x, player.transform.position.y, Desk.position.z);
        player.transform.LookAt(dskPos);
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
            pM.isMoving = true;
            pM.anim.SetFloat("Speed", 1);
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
