using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpHeight = 5.5f;

    Collider2D collider = null;

    Rigidbody2D body = null;
    readonly string GROUND = "Ground";

    float lastJump;

    //Actions action = Actions.Walk;

    void Start()
    {
        lastJump = Time.time;
        body = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && collider.IsTouchingLayers(LayerMask.GetMask(GROUND))&& Time.time - lastJump > 0.1)
        {
            body.velocity = body.velocity + Vector2.up * jumpHeight;
            lastJump = Time.time;
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
    }
}
