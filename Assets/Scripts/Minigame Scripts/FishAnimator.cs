using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Quaternion previousRotation;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        previousRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        animator.SetBool("Swimming", rb.velocity.magnitude > 1f || Quaternion.Angle(transform.rotation, previousRotation) > 1f);
        previousRotation = transform.rotation;
    }
}
