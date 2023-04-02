using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBearController : MonoBehaviour
{
    // Movement\
    [SerializeField] private float moveSpeed;
    private int horizontal;
    private int vertical;


    // Components
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");

        anim.SetInteger("SpeedX", horizontal);
        anim.SetInteger("SpeedY", vertical);

        rb.velocity = new Vector2(horizontal, vertical).normalized * moveSpeed;
    }
}
