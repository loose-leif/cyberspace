using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force = 100;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject Temp_bullet_Handler; // bullet happen
            Temp_bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject; //specifies object and postion to instantiate
            Temp_bullet_Handler.transform.Rotate(Vector3.left * 90); // rotation fix
            Rigidbody temp_rb; //access rigidbody from instantiated() bullet
            temp_rb = Temp_bullet_Handler.GetComponent<Rigidbody>();
            temp_rb.AddForce(transform.forward * Bullet_Forward_Force); // bullet force 
            Destroy(Temp_bullet_Handler, 10.0f);



            


        }
    }
}
