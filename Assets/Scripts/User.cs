using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rb;
    float xin;
    float zin;
    float moveSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // rb

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xin = Input.GetAxis("Horizontal"); //  left  and right keys
        zin = Input.GetAxis("Vertical"); // up and down 
        Debug.Log(xin);
        Debug.Log(zin);

       if (Input.GetKeyDown(KeyCode.W)) // ignore for now place holder for better movement
        {

        }
    }
    private void FixedUpdate()
    {
        float xVelocity = xInput * moveSpeed;
        float zVelocity = zInput * moveSpeed;

        rb.velocity = new Vector3(xVelocity, rb.velocity.y, zVelocity); // simple movement 
    }
}
