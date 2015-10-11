using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    // Use this for initialization
    public float Thrust;
    public bool UsePhysicsMovement;

    Rigidbody rb;
    float m_myAngle = 270.0f;
    
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        if(UsePhysicsMovement)
        {
            rb.isKinematic = false;
            transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
            transform.parent.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Update()
    {
        if (!UsePhysicsMovement)
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_myAngle -= Thrust;
                float zAngle = m_myAngle * Mathf.PI / 180.0f;
                float x = 4.0f * Mathf.Cos(zAngle);
                float y = 4.0f * Mathf.Sin(zAngle);
                this.transform.position = new Vector3(x, y, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_myAngle += Thrust;
                float zAngle = m_myAngle * Mathf.PI / 180.0f;
                float x = 4.0f * Mathf.Cos(zAngle);
                float y = 4.0f * Mathf.Sin(zAngle);
                this.transform.position = new Vector3(x, y, 0.0f);
            }
        }
    }

    void FixedUpdate()
    {
        if(UsePhysicsMovement)
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
}
