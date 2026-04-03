using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator mainAnimator;
    public Animator anim;

    public GameObject bulletPrefab;
    public Transform FirePoint;

    public float FireSpeed;

    Vector3 targetPoint;
    public LayerMask shootAble;

    public float Ammo;
    public int reloadedAmmo;


    Sounds AudScr;
    // Start is called before the first frame update
    void Start()
    {
        AudScr = GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        // From Camera Ray
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0) );
        if(Physics.Raycast(ray, out RaycastHit hit, 1000f, shootAble))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * 1000f;
        }


        //Shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && reloadedAmmo > 0 && !mainAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkingReload") && !mainAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleReload"))
        {
            anim.SetTrigger("Fire");
            FireBullet();
        }

        //Reload
        if(Input.GetKeyDown(KeyCode.R) && reloadedAmmo < 6 && Ammo > 0)
        {
            if(!mainAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkingReload") && !mainAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleReload"))
            {
                mainAnimator.SetTrigger("Reload");
                AudScr.reloadSound();
                StartCoroutine(Reload());
            }
            
        }
    }

    void FireBullet()
    {
        AudScr.fireSound();
        GameObject Bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        reloadedAmmo--;

        Vector3 Direction = (targetPoint - FirePoint.position).normalized;

        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        rb.velocity = Direction *FireSpeed;
    }
    IEnumerator Reload()
    {
        
        for(int i = reloadedAmmo; i < 6; i++)
        {
            if (Ammo > 0)
            {
                Ammo--;
                reloadedAmmo++;
                
            }
            yield return new WaitForSeconds(0.2f);
        }

       GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject b in bullets)
        {
            Destroy(b);
        }
    }
}
