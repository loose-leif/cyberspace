using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(gameObject);
    }
}
