using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public delegate void CoinHitHandler();

    public CoinHitHandler Coinhit;

    // Use this for initialization
    void Start () {
	    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -15.0f)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter()
    {

        Destroy(gameObject);

        if(Coinhit != null)
        {
            Coinhit();
        }
    }
    
}
