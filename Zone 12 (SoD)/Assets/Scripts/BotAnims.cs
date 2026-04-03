using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnims : MonoBehaviour
{
    public bool inCutScene = false;
    public string curAnim = "idle";
    public Transform target;
    Animator animC;
    // Start is called before the first frame update
    void Start()
    {
        animC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curAnim == "idle")
        {
            animC.SetBool("Driving", false);
            animC.SetBool("Walking", false);
        }else if (curAnim == "Driving")
        {
            animC.SetBool("Driving", true);
            animC.SetBool("Walking", false);
        }else if (curAnim == "Walking")
        {
            animC.SetBool("Driving", false);
            animC.SetBool("Walking", true);

            /*
            if(inCutScene)
            {
                StartCoroutine(goToTarget());
            }*/
            
        }
    }

    IEnumerator goToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);                transform.position = Vector3.MoveTowards(
        transform.position,
        target.position,
        5 * Time.deltaTime
        );
        curAnim = "idle";
        yield return new WaitForSeconds(2f);
    }
}
