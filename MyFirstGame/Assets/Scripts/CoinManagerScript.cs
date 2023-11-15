using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManagerScript : MonoBehaviour
{
    public Transform coinTemplate;
    public Transform player;
    public float activationRadius = 3f;

    Vector3[] coinLocalPositions = new Vector3[]
    {
        new Vector3(3.9f, 0.5f, 15.31f), //Coin 0
        new Vector3(13.77f, 0.5f, 10.98f), //Coin 1
        new Vector3(-2.2f, 0.5f, -2.81f), //Coin 2
        new Vector3(-2.13f, 0.5f, -12.85f), //Coin 3
        new Vector3(10.4f, 0.5f, -15.32f), //Coin 4
        new Vector3(-2.17f, 0.5f, -20.82f) //Coin 5
    };

    
    List<Transform> coins = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Vector3 localPosition in coinLocalPositions)
        {
            
            Vector3 worldPosition = transform.TransformPoint(localPosition);

            
            Transform newCoin = Instantiate(coinTemplate, worldPosition, Quaternion.identity);
            coins.Add(newCoin); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (Transform coin in coins.ToArray()) 
        {
            if (coin == null)
            {
               
                coins.Remove(coin);
                continue;
            }

            float distance = Vector3.Distance(coin.position, player.position);

            
            coin.gameObject.SetActive(distance <= activationRadius);
        }
    }
}
