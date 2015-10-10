using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public Rigidbody Coins;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float randomAngle = Random.Range(180, 360);
        float zAngle = randomAngle * Mathf.PI / 180.0f;
        float x = 4.0f * Mathf.Cos(zAngle);
        float y = 4.0f * Mathf.Sin(zAngle);
        Vector3 coinPosition = new Vector3(x, y, 20.0f);
        Rigidbody newCoin = (Rigidbody) Instantiate(Coins, coinPosition, Quaternion.identity);
        newCoin.velocity = new Vector3(0, 0, -10.0f);
	}
}
