using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    // Use this for initialization
    public float thrust;
    Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        Debug.Log("Actual position" + this.gameObject.transform.position);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * thrust);
        }
        float zAngle = (this.gameObject.transform.eulerAngles.z+270.0f)*Mathf.PI/180.0f;
        Debug.Log(this.gameObject.transform.eulerAngles.z);
        float x = 4.0f * Mathf.Cos(zAngle);
        float y = 4.0f * Mathf.Sin(zAngle);
        Debug.Log("Calculated position x" + x);
        Debug.Log("Calculated position y" + y);
        //     Debug.Log("Actual position" + this.gameObject.transform.position.x);
        Debug.Log("Actual position" + this.gameObject.transform.position);
    }
}
