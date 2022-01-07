using UnityEngine;
using System.Collections;

// nathan
// gun scripts taken from https://learn.unity.com/tutorial/let-s-try-shooting-with-raycasts?signup=true#

// this is the basic gun script.
// how to use?
// Use a cube, attach it to the camera. 
// Attach RayCastShoots (or gun equivalent), and RayViewer to the camera. 
// Attach a GunEnd to the end of the gun model.
// Add a LineRender to the camera.
// Put ShootableTarget on whatever target will be shot.
// if have questions ask nate.

public class ShootableTarget : MonoBehaviour {

    //The box's current health point total
    public int currentHealth = 10;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0) 
        {
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive (false);
        }
    }
}
