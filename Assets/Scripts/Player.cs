using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        
        if(rb.velocity.magnitude <= maximumVelocity)
        rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));
    }
    
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hazard")){
            Destroy(gameObject);
        }
    }
}
