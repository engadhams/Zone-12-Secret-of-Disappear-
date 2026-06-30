using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject cenCam;

    public GameObject player;
    Transform boat;
    Vector3 target;
    public bool boatMoving;

    [Header("Camera Positions")]
    public Transform pos1;
    public Transform pos2;
    public int curScene=0;
    void Start()
    {
        boat= GameObject.Find("PlayerBoat").transform;
        target = boat.position+ new Vector3(-95,0,0);

        StartCoroutine(Scene1(3));
    }

    void FixedUpdate()
    {
        
        if(boatMoving)
        {
            boat.position= Vector3.Lerp(boat.position, target, 0.5f*Time.fixedDeltaTime);
        }
    }

    void stopPlayeMovement()
    {
        player.GetComponent<playerMovement>().isAbletoMove=false;
        player.GetComponent<playerMovement>().isAbletoLook=false;
    }

    IEnumerator Scene1(float Secs)
    {
        mainCam.SetActive(false);
        cenCam.SetActive(true);
        cenCam.transform.position = pos1.position;
        player.transform.SetParent(boat);
        stopPlayeMovement();
        yield return new WaitForSeconds(Secs);
        boatMoving=true;
        
    }
}
