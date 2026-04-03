using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject ammoValues;
    public Text Ammo;
    public Text reloadAmmo;

    public Image selWeapon;
    public Sprite knife;
    public Sprite pistol;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            selWeapon.sprite = knife;
        }else if (Input.GetKey(KeyCode.Alpha2))
        {
            selWeapon.sprite = pistol;
        }

        reloadAmmo.text = ammoValues.GetComponent<Fire>().reloadedAmmo.ToString();
        Ammo.text = "/" + ammoValues.GetComponent<Fire>().Ammo.ToString();
        
    }
}
