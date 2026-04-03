using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject pistol;
    public GameObject knife;

    public Animator anim;

    public RuntimeAnimatorController NormalController;
    public RuntimeAnimatorController pistolController;
    public RuntimeAnimatorController rifleController;
    // Start is called before the first frame update
    void Start()
    {
        anim.runtimeAnimatorController = NormalController;
        pistol.SetActive(false);
        knife.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            meleeMode();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            pistol.SetActive(true);
            knife.SetActive(false);
            anim.runtimeAnimatorController = pistolController;
        }
      /*if (Input.GetKey(KeyCode.Alpha3))
        {
            pistol.SetActive(false);
            knife.SetActive(false);
            anim.runtimeAnimatorController = rifleController;
        }
      */

        if(Input.GetKeyDown(KeyCode.Mouse0) && anim.runtimeAnimatorController == NormalController)
        {
            anim.SetTrigger("Melee");
        }
    }

    void meleeMode()
    {
        pistol.SetActive(false);
        knife.SetActive(true);
        anim.runtimeAnimatorController = NormalController;
    }
    public void noGun()
    {
        pistol.SetActive(false);
        knife.SetActive(false);
        anim.runtimeAnimatorController = NormalController;
    }
}
