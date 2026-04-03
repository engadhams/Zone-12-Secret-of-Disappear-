using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public BotAnims AIMoves;
    public Cinema cen;
    public bool isPlaying = false;
    public AudioSource audScr;
    
    [Header("Scene1")]
    public AudioClip vc1;
    public AudioClip vc2;

    [Header("Scene3")]
    public AudioClip vc4;
    public AudioClip vc5;
    public AudioClip vc6;
    public AudioClip vc7;

    // المحادثة الأولى في القاعدة البحرية
    IEnumerator scene1()
    {
        isPlaying = true;

        audScr.clip = vc1;
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length + 0.5f);

        isPlaying = false;
        cen.curScene = 0;
        cen.scenesCompleted = 1;
        cen.Player.GetComponent<PlayerMovement>().canMove = true;
        cen.Player.GetComponent<PlayerMovement>().canRotate = true;
    }

    // مشهد انظلاق القارب
    IEnumerator scene2()
    {
        audScr.clip = vc2;
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length);

        cen.curScene = 0;
        cen.scenesCompleted = 2;
        cen.Player.GetComponent<PlayerMovement>().canRotate = true;
        cen.Player.GetComponent<PlayerMovement>().canMove = true;
    }

    IEnumerator scene3()
    {
        isPlaying = true;
        audScr.clip = vc4;
        yield return new WaitForSeconds(1.5f);
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length +0.5f);
        
        audScr.clip = vc5;
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length);

        
    }
    IEnumerator scene3C()
    {
        audScr.clip = vc6;
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length+3);

        audScr.clip = vc7;
        audScr.Play();
        yield return new WaitForSeconds(audScr.clip.length+1);
    }

    // أكواد استدعاء أوامر الانتظار
    public void startSC1()
    {
        StartCoroutine(scene1());
    }
    public void startSC2()
    {
        StartCoroutine(scene2());
    }
    public void startSC3()
    {
        StartCoroutine(scene3());
    }
    public void continueSC3()
    {
        StartCoroutine(scene3C());
    }
}
