using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public int Collect = 0;
    public Text collectText;

    bool JOHN = false;
    public void Update()
    {
        
        if(JOHN){
            
            Collect = Collect + 1;
            collectText.text = "Collectible: " + Collect.ToString();
            JOHN = false;

        }
        
    }


    // Start is called before the first frame update

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "Collectible") // Collision Made with collectible object
        {
            
            JOHN = true;
            Destroy(collision.gameObject);
        

        }
    }
}
