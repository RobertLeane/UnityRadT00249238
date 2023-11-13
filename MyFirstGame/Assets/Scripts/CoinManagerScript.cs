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

    // List to store references to instantiated coins
    List<Transform> coins = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate coins at the specified positions
        foreach (Vector3 localPosition in coinLocalPositions)
        {
            // Convert local position to world space
            Vector3 worldPosition = transform.TransformPoint(localPosition);

            // Instantiate coin
            Transform newCoin = Instantiate(coinTemplate, worldPosition, Quaternion.identity);
            coins.Add(newCoin); // Add the coin to the list
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the player and each coin
        foreach (Transform coin in coins.ToArray()) // Use ToArray to create a copy of the list
        {
            if (coin == null)
            {
                // The coin has been destroyed, remove it from the list
                coins.Remove(coin);
                continue;
            }

            float distance = Vector3.Distance(coin.position, player.position);

            // Activate/deactivate the coin based on the distance
            coin.gameObject.SetActive(distance <= activationRadius);
        }
    }
}
