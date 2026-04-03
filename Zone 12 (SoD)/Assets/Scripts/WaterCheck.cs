using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheck : MonoBehaviour
{

    Rigidbody rb;
    public bool inWater = false;

    public float waterLevel;
    public float waterDrag = 3f;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(inWater)
        {
            float difference =  transform.position.y - waterLevel;
            rb.drag = waterDrag;
            
            if (difference < -0.2f)
            {
                Debug.Log(difference);
                rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
            }
                
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            inWater = true;
            waterLevel = other.transform.position.y;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water"))
        {
            inWater = false;
            
        }
    }
}
