using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void Awake()
    {
       // rb = GetComponent<Rigidbody>(); // rb

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

       if (Input.GetKeyDown(KeyCode.W)) // ignore for now place holder for better movement
        {
            transform.position += Vector3.forward;
        }
       if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0,2,0);
        }
    }
    
 
}
