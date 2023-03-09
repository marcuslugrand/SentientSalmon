using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishController : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    public float deceleration;
    public float turnSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        // Move the fish forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Calculate the acceleration vector
            Vector2 accelerationVector = transform.up * acceleration;
            rb.velocity += accelerationVector * Time.fixedDeltaTime;
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeed);
        }
        else
        {
            rb.velocity -= rb.velocity.normalized * deceleration * Time.fixedDeltaTime;
            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector2.zero;
            }
        }

        // Turn the fish left or right
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.fixedDeltaTime);
        }
    }
}
