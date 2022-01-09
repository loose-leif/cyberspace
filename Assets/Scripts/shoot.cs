using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public GameObject bombll;
    public float Bullet_Forward_Force = 100;
    public float bombll_Forward_Force = 100;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Temp_bullet_Handler; // bullet happen
            Temp_bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject; //specifies object and postion to instantiate
            Temp_bullet_Handler.transform.Rotate(Vector3.left * 90); // rotation fix
            Rigidbody temp_rb; //access rigidbody from instantiated() bullet
            temp_rb = Temp_bullet_Handler.GetComponent<Rigidbody>();
            temp_rb.AddForce(transform.forward * Bullet_Forward_Force); // bullet force 
            Destroy(Temp_bullet_Handler,3.0f);
        }
        if(Input.GetMouseButtonDown(1))
        {
            GameObject Temp_bombll_Handler; // bullet happen
            Temp_bombll_Handler = Instantiate(bombll, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject; //specifies object and postion to instantiate
            Temp_bombll_Handler.transform.Rotate(Vector3.left * 90); // rotation fix
            Rigidbody temp_rb2; //access rigidbody from instantiated() bombll
            temp_rb2 = Temp_bombll_Handler.GetComponent<Rigidbody>();
            temp_rb2.AddForce(transform.forward * bombll_Forward_Force); // bombll force 
            Destroy(Temp_bombll_Handler, 3.0f);






        }

    }
}
