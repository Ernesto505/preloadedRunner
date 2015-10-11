using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public Rigidbody Coins;
    int m_coinsHit = 0;
    int m_updateCounter = 0;
    float m_initialAngle = 0.0f;
    float m_randomDistance = 0.0f;

    public Text CoinsCounterText;

	// Use this for initialization
	void Start ()
    {
        getRandomNumbers();
    }

    public void Subscribe(Coin myCoin)
    {
        myCoin.Coinhit += new Coin.CoinHitHandler(CoinHasBeenHit);
    }

    // Update is called once per frame
    void Update ()
    {
        m_updateCounter++;

        if (m_updateCounter % 20==0)
        {
            m_initialAngle += m_randomDistance;

            if (m_initialAngle < 180.0f || m_initialAngle>360.0f) 
            {
                getRandomNumbers();
            }

            float zAngle = m_initialAngle * Mathf.PI / 180.0f;
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

    void getRandomNumbers()
    {
        m_initialAngle = Random.Range(180.0f, 360.0f);
        m_randomDistance = Random.Range(-20.0f, 20.0f);
        if (m_randomDistance > -2.0 && m_randomDistance < 2.0f)
        {
            m_randomDistance = 2.0f;
        }
    }

}
