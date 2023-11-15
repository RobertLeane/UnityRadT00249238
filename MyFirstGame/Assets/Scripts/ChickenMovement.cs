using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, 180 * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -180 * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * 0.02f;

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}

