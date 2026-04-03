using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float horiz;
    public float vert;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horiz = Input.GetAxis("Horizontal");
       vert = Input.GetAxis("Vertical");
       
    }
}
