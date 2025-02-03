using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyaMovementAnimations : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float speed = Mathf.Abs(rb.velocity.x + rb.velocity.y);
        animator.SetFloat("Speed", speed);
    }

    // Public Animation Setters
    public void setBrake(Boolean isBraking) {
        animator.SetBool("Brake", isBraking);
    }
}
