using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidSalmonMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        rb.velocity = new Vector2(0f, moveSpeed);
    }
}
