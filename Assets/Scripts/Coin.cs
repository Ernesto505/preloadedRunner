﻿using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public delegate void CoinHitHandler(bool badCoin);

    public CoinHitHandler Coinhit;

    public bool IsBadCoin = false;

    // Use this for initialization
    void Start ()
    {
	    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.z < -15.0f)
        {
            Destroy(gameObject);
        }

        transform.Rotate(1,0 , 0);
	}

    public void setCoinAsBad()
    {
        IsBadCoin = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

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
