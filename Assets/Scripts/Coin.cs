using UnityEngine;
using System.Collections;

//this script is attached in every coin
public class Coin : MonoBehaviour {

    public delegate void CoinHitHandler(bool badCoin);

    public CoinHitHandler Coinhit;

    public bool IsBadCoin = false;

    void Start ()
    {
	    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.0f);
    }
	
	void Update ()
    {
        //the coins are destroyed when they go beyond the camera
        if (transform.position.z < -15.0f)
        {
            Destroy(gameObject);
        }

        transform.Rotate(1,0 , 0);
	}

    //this changes the color of a coin if it is defined as bad
    public void setCoinAsBad()
    {
        IsBadCoin = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    //this handles the collision with the Player and triggers the functions that are subscibed to Coinhit event
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {
            Destroy(gameObject);

            if (Coinhit != null)
            {
                Coinhit(IsBadCoin);
            }
        }

    }
    
}
