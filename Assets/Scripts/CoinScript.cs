using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    public int coinValue;
    public TextMeshPro valueText;
    public SpriteRenderer sr;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        //ChangeCoinColor(Random.ColorHSV());
        //ChangeCoinValue(Random.Range(1, 9));
         rb = GetComponent<Rigidbody2D>();
    }

    public void SpawnCoin()
    {
        rb.velocity = new Vector3(0, Random.Range(-5, -10));
    }
   
    public void ChangeCoinColor(Color c)
    {
        sr.color = c;
    }

    public void ChangeCoinValue(int v)
    {
        coinValue = v;
        valueText.text = coinValue.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().IncrementScore(coinValue);
            Destroy(gameObject);
        }
    }
}
