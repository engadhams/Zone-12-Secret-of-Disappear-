using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : MonoBehaviour
{
    public Cinema cen;
    public GameObject MotorWSmoke;
    public GameObject MotorRSmoke;
    public ParticleSystem[] Zone12Ps;
    public GameObject Zone12;
    public void Scene3Start()
    {
        // الدخول في وضع المشي العادي
        cen.Player.GetComponent<PlayerMovement>().canMove = true;
        cen.Player.GetComponent<PlayerMovement>().canRotate = true;
        cen.voices.isPlaying = false;
        cen.Player.transform.SetParent(null);
        


        // المشهد والأدخنة
        StartCoroutine(DoSmoke());
    }

    IEnumerator DoSmoke()
    {
        yield return new WaitForSeconds(2f);
        cen.voices.continueSC3();
        yield return new WaitForSeconds(5f);
        cen.soundScr.radioNoise();
        yield return new WaitForSeconds(25f);

        // الأدخنة
        Zone12.SetActive(true);
        foreach(ParticleSystem ps in Zone12Ps)
        {
            var Main = ps.main;
            Main.simulationSpeed = 0.05f;
        }
    }
}
