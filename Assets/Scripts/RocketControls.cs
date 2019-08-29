using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour
{

    [SerializeField] float trustScale = 3;
    [SerializeField] float turnScale = 5;

    float currentRotation = 0;

    // Update is called once per frame
    void Update()
    {
        Turn();
        Trust();
        if (Input.GetKey(KeyCode.R))
        {
            this.transform.position = Vector3.zero;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void Trust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.rotation * Vector3.up * trustScale);
        }
    }

    void Turn()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody2D>().MoveRotation(currentRotation + turnScale);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Rigidbody2D>().MoveRotation(currentRotation + -turnScale);
        }
        currentRotation = this.GetComponent<Rigidbody2D>().rotation;
    }
}
