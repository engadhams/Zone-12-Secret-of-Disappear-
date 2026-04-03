using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinema : MonoBehaviour
{
    [Header("Scene 1&2 script, Main Code")]
    public Camera mainCam;
    public Camera cenCam;
    [Header("CamPos")]
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    [Header("Scenes Objects")]
    public GameObject Player;
    public GameObject scene1_tgObj;
    public GameObject scene2_boat;
    public bool BoatMove = false;
    public Transform target;
    [Header("Values")]
    float boatSpeed = 0.1f;
    public int scenesCompleted = 0;
    public int curScene;

    [Header("Scripts")]
    Animations plAnim;
    public WeaponScript gunSel;
    public Voice voices;
    public BotAnims AIMoves;
    public Sounds soundScr;
    [Header("Other Scenes Scripts")]
    public Scene3 scene3;
    // Start is called before the first frame update
    void Start()
    {
        plAnim = Player.GetComponent<Animations>();
        mainCam.enabled = true;
        cenCam.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //مشاهد تحتاج Loop
        if(curScene == 1)
        {
            scene1();
        }

        //عد إلى الوضع الطبيعي
        if(curScene == 0)
        {   
            mainCam.enabled = true;
            cenCam.enabled = false;
        }
        //حركة القارب
        if(BoatMove)
        {
            
            if(soundScr.isPlaying == false)
            {
                soundScr.BoatMotorSound();
            }

            // الدوران ناحيته (Y فقط)
            Vector3 lookPos = target.position;
            lookPos.y = scene2_boat.transform.position.y;
            scene2_boat.transform.LookAt(lookPos);
            
            // كود الحركة والسرعة
            scene2_boat.transform.position = scene2_boat.transform.position + scene2_boat.transform.forward*boatSpeed* Time.timeScale;

            if(Vector3.Distance(scene2_boat.transform.position, target.transform.position) < 300f && curScene == 0)
            {
                BoatDecel();
            }
            else
            {
                BoatAccel();
            }
        }
        
    }

    // التسارع التدريجي للقارب
    void BoatAccel()
    {
        if(boatSpeed < 0.5f)
        {
            soundScr.src.volume = boatSpeed;
            boatSpeed += 0.001f;
        }
    }
    // التباطئ التدريجي للقارب
    void BoatDecel()
    {
        // حرق المحرك
        scene3.MotorRSmoke.SetActive(false);
        scene3.MotorWSmoke.SetActive(true);
        soundScr.src.pitch = 3;

        if(!voices.isPlaying)
        {
            voices.startSC3();
        }
        if(boatSpeed > 0)
        {
            soundScr.src.volume = boatSpeed;
            boatSpeed -= 0.001f;
        }
        else
        {
            BoatMove = false;
            scene3.Scene3Start();
        }
    }


    public void goForScene()
    {
        //الكود الشرطي المسئول عن تنفيذ المشاهد
        if(curScene == 1)
        {
            curScSetting(pos1);

        }else if(curScene == 2){

            scene2();

        }else if(curScene == 3){

            curScSetting(pos2);
            scene2Finish();

        }
        // نهايته
    }


    // المشهد الأول
    void scene1()
    {
        //كود حساب المسافة بين اللاعب والمكتب
        float distance = Vector3.Distance(scene1_tgObj.transform.position, Player.transform.position);
        if(distance > 1.7f)
        {
            Vector3 lookPos = scene1_tgObj.transform.position;
            lookPos.y = Player.transform.position.y;

            Player.transform.LookAt(lookPos);

            plAnim.anim.SetBool("Walk", true);
            Player.transform.position = Player.transform.position + Player.transform.forward *0.03f;
        }
        else
        {
            // عند الوصول للمكتب يستدعي أكواد المحادثة من Voice Script;
            plAnim.anim.SetBool("Walk", false);
            if(!voices.isPlaying)
            {
                voices.startSC1();
            }
        }
    }

    //المشهد الثاني
    void scene2()
    {

        // انطلاق القارب بعد المحادثة
        voices.startSC2();
    }
    void scene2Finish()
    {
        BoatMove = true;
        plAnim.anim.SetBool("Walk", false);

        // الحركة
        Player.transform.SetParent(scene2_boat.transform);
        Player.transform.position = GameObject.Find("chairpos").transform.position;
        Player.GetComponent<PlayerMovement>().canRotate = true;
        StartCoroutine(finsihSc2());
    }
    IEnumerator finsihSc2()
    {
        yield return new WaitForSeconds(5f);
        target = GameObject.Find("MoveTarget2").transform;
        curScene = 0;
        scenesCompleted = 3;
        
    }

    // الأكودا الأساسية في الانتقال لكل المشاهد
    public void curScSetting(Transform camPos)
    {
        gunSel.noGun();
        mainCam.enabled = false;
        Player.GetComponent<PlayerMovement>().canMove = false;
        Player.GetComponent<PlayerMovement>().canRotate = false;
        cenCam.enabled = true;

        cenCam.gameObject.GetComponent<Transform>().position = camPos.position;
        cenCam.gameObject.GetComponent<Transform>().rotation = camPos.rotation;
    }

    
}
