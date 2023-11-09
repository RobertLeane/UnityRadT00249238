using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{
    Rigidbody rb;
    float kickStrength = 800;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void KickBall(Transform kicker)
    {
        rb.AddExplosionForce(kickStrength, kicker.position, 4);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        { print("Boing!!"); }
        else
        {
           
            print("Ouch");

            KickBall(collision.transform);
        }
    }
}
