using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float FallMultiplier = 5f;
    public float lowJumpMultiplier = 2.5f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.AddForce( new Vector3(0, 1, 0) * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime);
        } else if (rb.velocity.y > 0 && !Input.GetButton("Space"))
        {
            rb.velocity +=new Vector3(0, 1, 0) * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
