using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // public integers and boolean variables
    public int speed;
    public bool movement;

    // public variables for rigidbody2d and location of paddle
    public Rigidbody2D rb;
    public Transform paddle;

    // start function to get rigidbody2d components
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // update function for ball movement
    void Update()
    {
        // if statement detects if the ball is moving 
        if (!movement)
        {
            transform.position = paddle.position;
        }

        // if statement for paddle controls
        if (Input.GetButtonDown("Jump") && !movement)
        {
            movement = true;
            rb.AddForce(Vector2.up * speed);
            rb.AddForce(Vector2.right * (speed / 2));
        }
    }

    // trigger detection for ball falling out of bounds (oob)
    void OnTriggerEnter2D(Collider2D other)
    {
        // if statement to clarify the collider
        if (other.gameObject.tag == "oob")
        {
            // remove force on ball
            rb.velocity = Vector2.zero;

            // reset boolean
            movement = false;
        }
    }

    // collision detection for colliding with bricks
    void OnCollisionEnter2D(Collision2D other)
    {
        // if statement to clarify correct game objects
        if (other.gameObject.tag == "Brick")
        {
            // destroy bricks
            Destroy(other.gameObject);
        }
    }
}
