using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public Transform footballCloneTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        transform.position += transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up,180 * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -180 * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * 0.02f;
        if (Input.GetKeyDown(KeyCode.Return))
        {
           Transform newBall = Instantiate(footballCloneTemplate, 
                transform.position + 2*transform.forward,
                Quaternion.identity);
            BallControlScript myNewBallScript = 
                newBall.GetComponent<BallControlScript>();

            myNewBallScript.KickBall(transform);


        }
    }
}
