using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//the game manager class that handles level generation, collisions, sound effects and keeps track of the score
public class CoinManager : MonoBehaviour {

    public GameObject Coins;

    public AudioSource Speaker;
    public AudioClip GoodCollect;
    public AudioClip BadCollect;

    int m_coinsHit = 0;
    int m_updateCounter = 0;
    int m_numberOfCoins = 0;
    float m_initialAngle = 0.0f;
    float m_randomAngleDistance = 0.0f;
    

    public Text CoinsCounterText;

	void Start ()
    {
        getRandomNumbers();
    }

    //this class subscribes CoinHasBeenHit handler function to the relevant delegate
    public void Subscribe(Coin myCoin)
    {
        myCoin.Coinhit += new Coin.CoinHitHandler(CoinHasBeenHit);
    }

    void FixedUpdate ()
    {
        m_updateCounter++;

        //a new coin is created every 4 fixed updates
        if (m_updateCounter % 4==0)
        {
            //this keeps track of the number of coins that are created so
            //bad coins can be created in regular intervals 
            m_numberOfCoins++;

            //the position of the coins is inside the semicircle that has center(0,0) radius 4
            //and is defined between the angles {180,360}
            //every time a new coin is created the next one is positioned a bit further until the angle exceeds 
            //the limits of the semicircle
            m_initialAngle += m_randomAngleDistance;

            //everytime the angle exceeds the limits of the semicircle a new random angle is picked as a starting angle
            //and a new random angle as the random angle distance 
            if (m_initialAngle < 180.0f || m_initialAngle>360.0f) 
            {
                getRandomNumbers();
            }

            //the position of the next coin is calculated here and the new coin is instantiated
            float zAngle = m_initialAngle * Mathf.PI / 180.0f;
            float x = 4.0f * Mathf.Cos(zAngle);
            float y = 4.0f * Mathf.Sin(zAngle);
            Vector3 coinPosition = new Vector3(x, y, 20.0f);
            GameObject newCoin = (GameObject) Instantiate(Coins, coinPosition, Quaternion.Euler(-45,-45,-45));

            createBadCoins(newCoin);

            Subscribe(newCoin.gameObject.GetComponent<Coin>());
            m_updateCounter = 0;
        }
    }

    //this is the method that handles the coin hit event
    //it takes one bool parameter that defines if the coin is a "bad" coin or not
    void CoinHasBeenHit(bool isBadCoin)
    {
        if(!isBadCoin)
        {
            m_coinsHit++;
            Speaker.PlayOneShot(GoodCollect,0.1f+((float)m_coinsHit/400.0f));
        }
        else
        {
            Speaker.PlayOneShot(BadCollect, 0.1f + ((float)m_coinsHit / 400.0f));
            m_coinsHit = 0;
        }
        
        CoinsCounterText.text = "Diamonds: " + m_coinsHit.ToString();
    }

    //this method creates the random numbers that are required for the level generation
    void getRandomNumbers()
    {
        m_initialAngle = Random.Range(180.0f, 360.0f);
        m_randomAngleDistance = Random.Range(-20.0f, 20.0f);

        //if randomAngleDistance is smaller than 2 in order to avoid big lines 2 is picked as a value 
        if (m_randomAngleDistance > -2.0 && m_randomAngleDistance < 2.0f)
        {
            m_randomAngleDistance = 2.0f;
        }
    }

    //when the hitcounter reaches a certain number "bad" coins start to be created
    //the bigger the hitcounter gets the more "bad" coins are created
    void createBadCoins(GameObject coin)
    {
        int coinsRatio = m_coinsHit / 30;
        if (coinsRatio > 0 && m_numberOfCoins%(30/coinsRatio)==0)
        {
            coin.GetComponent<Coin>().setCoinAsBad();
        }
    }

}
