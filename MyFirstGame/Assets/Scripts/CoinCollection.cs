using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class CoinCollection : MonoBehaviour
{
    private int Coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Coins: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);

        }
        if(Coin == 6)
        {
            Debug.Log("Congratulations, You Collected All The Coins!");
        }
    }
}
