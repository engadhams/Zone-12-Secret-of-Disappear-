using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour {
    public Rigidbody rb;
    public float rollForce = 20f;   
    public float rollDuration = 0.3f;   
    public float rollCooldown = 0.5f;   

    [Header("Audio Settings")]
    public AudioSource audioSource; // اسحب الـ AudioSource هنا
    public AudioClip dodgeSound;    // اسحب ملف الصوت هنا

    private bool isRolling = false;
    private bool canRoll = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
        
        // محاولة البحث عن AudioSource إذا لم يتم تعيينه
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canRoll && !isRolling) {
            StartCoroutine(PerformDodge());
        }
    }

    IEnumerator PerformDodge() {
        isRolling = true;
        canRoll = false;

        // تشغيل الصوت عند ضغط الزر مباشرة
        if (audioSource != null && dodgeSound != null) {
            audioSource.PlayOneShot(dodgeSound);
        }

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        Vector3 rollDir = transform.forward; 
        rollDir.y = 0;
        rollDir.Normalize();

        rb.velocity = Vector3.zero; 

        rb.AddForce(rollDir * rollForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(rollDuration);

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        isRolling = false;

        yield return new WaitForSeconds(rollCooldown);
        canRoll = true;
    }
}
