using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500f; // سرعة التحريك

    float horizontalInput;
    float verticalInput;

    void Update()
    {
        // استقبال المدخلات من اللاعب (Update)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // تطبيق الحركة الفيزيائية (FixedUpdate)
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        
        // استخدام AddForce لإضافة قوة دفع للجسم
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
