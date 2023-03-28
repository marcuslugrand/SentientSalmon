using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBearController : MonoBehaviour
{
    // Movement\
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float lungeLength;
    [SerializeField]
    private float lungeCooldown;
    [SerializeField]
    private float lungeSpeed;
    private float lungeTimer = 0f;
    private float lungeCooldownTimer = 0f;
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

        anim.SetInteger("SpeedX", 0);
        anim.SetInteger("SpeedY", 0);

        if (lungeCooldownTimer < 0){
            anim.SetInteger("SpeedX", horizontal);
            anim.SetInteger("SpeedY", vertical);

            rb.velocity = new Vector2(horizontal, vertical).normalized * moveSpeed;
        }

        if (lungeTimer < 0 && lungeCooldownTimer > 0){
            rb.velocity = Vector2.zero;
        }

        lungeTimer -= Time.deltaTime;
        lungeCooldownTimer -= Time.deltaTime;

        if (lungeCooldownTimer < 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse1))){
            rb.velocity = new Vector2(horizontal, vertical) * lungeSpeed;
            lungeCooldownTimer = lungeCooldown;
            lungeTimer = lungeLength;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "AI Salmon"){
            Destroy(other.gameObject);
        }
    }
}
