using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public GameObject bombll;
    public float Bullet_Forward_Force = 100;
    public float bombll_Forward_Force = 100;
    public int maxAmmo = 10;
    public float reloadTime = 2f;
    private bool isreloading = false;
    private int presentAmmo = -1;
    GameObject[] Ammo;

    //public Text Ammo;

    void Start()
    { if (presentAmmo == -1)
            presentAmmo = maxAmmo;
        Ammo = GameObject.FindGameObjectsWithTag("Ammo");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isreloading)
        { 
            return;
        }

        if (Input.GetKeyDown(KeyCode.R)) //reloading...
            { 

            StartCoroutine(reload());
            return;
        }
        if (presentAmmo <= 0)
        {
            
            StartCoroutine(reload()); //reloading  when 0
            return;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            presentAmmo--;
           
            GameObject Temp_bullet_Handler; // bullet happen
            Temp_bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject; //specifies object and postion to instantiate
            Temp_bullet_Handler.transform.Rotate(Vector3.left * 90); // rotation fix
            Rigidbody temp_rb; //access rigidbody from instantiated() bullet
            temp_rb = Temp_bullet_Handler.GetComponent<Rigidbody>();
            temp_rb.AddForce(transform.forward * Bullet_Forward_Force); // bullet force 
            Destroy(Temp_bullet_Handler,20.0f);


        }
        if(Input.GetMouseButtonDown(1))
        {
            
            GameObject Temp_bombll_Handler; // bullet happen
            Temp_bombll_Handler =  Instantiate(bombll, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject; //specifies object and postion to instantiate
            Temp_bombll_Handler.transform.Rotate(Vector3.left * 90); // rotation fix
            Rigidbody temp_rb2; //access rigidbody from instantiated() bombll
            temp_rb2 = Temp_bombll_Handler.GetComponent<Rigidbody>();
            temp_rb2.AddForce(transform.forward * bombll_Forward_Force); // bombll force 
            Destroy(Temp_bombll_Handler, 3.0f);

        }
        
        IEnumerator reload() // the time it takes to reload and resets presentAmmo
        {
            Debug.Log("Reloading...");
            isreloading = true;
            yield return new WaitForSeconds(reloadTime); // reloading...
            presentAmmo = maxAmmo;// reset
            isreloading = false;
            Debug.Log("Finished");




        }
        if (presentAmmo > maxAmmo)
        {
            presentAmmo = maxAmmo;
        }
        
        

    }
    
    private void UpdateAmmo()
    {
       //Ammo.text = $"{presentAmmo}: " + presentAmmo.ToString();
    }
    public void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Ammo")
        {
            presentAmmo = maxAmmo;
            Destroy(other.gameObject);


        }

        
    }


}
