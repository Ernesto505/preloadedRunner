using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public Rigidbody Coins;
    int m_coinsHit = 0;
    int m_updateCounter = 0;

    public Text CoinsCounterText;

	// Use this for initialization
	void Start ()
    {

	}

    public void Subscribe(Coin myCoin)
    {
        myCoin.Coinhit += new Coin.CoinHitHandler(CoinHasBeenHit);
    }

    // Update is called once per frame
    void Update ()
    {
        m_updateCounter++;

        if (m_updateCounter % 30==0)
        { 
            float randomAngle = Random.Range(180, 360);
            float zAngle = randomAngle * Mathf.PI / 180.0f;
            float x = 4.0f * Mathf.Cos(zAngle);
            float y = 4.0f * Mathf.Sin(zAngle);
            Vector3 coinPosition = new Vector3(x, y, 20.0f);
            Rigidbody newCoin = (Rigidbody) Instantiate(Coins, coinPosition, Quaternion.identity);
            Subscribe(newCoin.gameObject.GetComponent<Coin>());
            m_updateCounter = 0;
        }
    }

    void CoinHasBeenHit()
    {
        m_coinsHit++;

        CoinsCounterText.text = m_coinsHit.ToString();
    }
}
