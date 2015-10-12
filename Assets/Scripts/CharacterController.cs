using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    
    public float Thrust;

    //this defines if the player will move using physics or not 
    public bool UsePhysicsMovement = false;

    Rigidbody rb;

    //the starting angle of the player in the circle that defines the moving path 
    float m_myAngle = 270.0f;
    
    void Start()
    {

        rb = this.gameObject.GetComponent<Rigidbody>();
        
        //here is checked if the player will move using physics or not
        if (UsePhysicsMovement)
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
            //if the player is not moving using physics the position is calculated 
            //in a circle that has center (0,0) and radius 4
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

        //this is for aesthetic reasons
        transform.Rotate(0, 1, 0);
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
