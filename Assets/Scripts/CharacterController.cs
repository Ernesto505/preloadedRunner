using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    // Use this for initialization
    public float Thrust;
    Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * Thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * Thrust);
        }
    }
}
