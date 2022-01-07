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

public class RayViewer : MonoBehaviour {

    public float weaponRange = 50f;                       // Distance in Unity units over which the Debug.DrawRay will be drawn

    private Camera fpsCam;                                // Holds a reference to the first person camera


    void Start () 
    {
        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update () 
    {
        // Create a vector at the center of our camera's viewport
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Draw a line in the Scene View  from the point lineOrigin in the direction of fpsCam.transform.forward * weaponRange, using the color green
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
    }
}