using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public GameObject Coins;
    int m_coinsHit = 0;
    int m_updateCounter = 0;
    int m_numberOfCoins = 0;
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
    void FixedUpdate ()
    {
        m_updateCounter++;

        if (m_updateCounter % 10==0)
        {
            m_numberOfCoins++;
            m_initialAngle += m_randomDistance;

            if (m_initialAngle < 180.0f || m_initialAngle>360.0f) 
            {
                getRandomNumbers();
            }

            float zAngle = m_initialAngle * Mathf.PI / 180.0f;
            float x = 4.0f * Mathf.Cos(zAngle);
            float y = 4.0f * Mathf.Sin(zAngle);
            Vector3 coinPosition = new Vector3(x, y, 20.0f);
            GameObject newCoin = (GameObject) Instantiate(Coins, coinPosition, Quaternion.identity);

            createBadCoins(newCoin);

            Subscribe(newCoin.gameObject.GetComponent<Coin>());
            m_updateCounter = 0;
        }
    }

    void CoinHasBeenHit(bool isBadCoin)
    {
        if(!isBadCoin)
        {
            m_coinsHit++;
        }
        else
        {
            m_coinsHit = 0;
        }
        
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

    void createBadCoins(GameObject coin)
    {
        int coinsRatio = m_coinsHit / 20;
        if (coinsRatio > 0 && m_numberOfCoins%(20/coinsRatio)==0)
        {
            coin.GetComponent<Coin>().setCoinAsBad();
        }
    }

}
