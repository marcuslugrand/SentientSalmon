using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidSalmonMovement : MonoBehaviour
{
    [SerializeField]
    private float minMoveSpeed;
    [SerializeField]
    private float maxMoveSpeed;
    private float moveSpeed;
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Update(){
        rb.velocity = new Vector2(0f, moveSpeed);
    }
}
