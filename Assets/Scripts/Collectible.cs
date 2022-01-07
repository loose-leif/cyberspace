using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public int Collect = 0;
    public Text collectText;
    public void Update()
    {
        collectText.text = "Collectible: " + Collect.ToString();
    }


    // Start is called before the first frame update

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "Collectible") // Collision Made with collectible object
        {
            Collect = Collect + 1;
            Destroy(collision.gameObject);
            


        }
    }
}
