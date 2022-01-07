using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 15;
    public float moveup = 100;

    // Start is called before the first frame update
    private void Awake()
    {
         rb = GetComponent<Rigidbody>(); // rb
      
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.A)) // ignore for now place holder for better movement
        {
            rb.AddForce(new Vector3(0, 0, moveSpeed), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-moveSpeed, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -moveSpeed), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, moveup, 0), ForceMode.Impulse);
        }
    }
    


}
