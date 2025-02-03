using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Alya Stats")]
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float slidingFactor;

    private Vector2 targetVector; // this is the final calculated value for desired direction and speed

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        ProcessInputs();
    }

    void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        targetVector = new Vector2(x, y).normalized;

        if (x > 0) {
            Flip(true);
        } else if (x < 0) {
            Flip(false);
        } 
        
        // // Animations
        // AlyaMovementAnimations animator = FindObjectOfType<AlyaMovementAnimations>();
        // if (Math.Abs(x) <= 0.15f) {
        //     animator.setBrake(true);
        // } else {
        //     animator.setBrake(false);
        // }
    }

    void Move() {
        Vector2 targetVelocity = new Vector2(targetVector.x * speedX, targetVector.y * speedY);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, slidingFactor);
    }

    private void Flip(bool facingRight) {
        Vector2 localScale = transform.localScale;
        if (facingRight && localScale.x < 0 || !facingRight && localScale.x > 0) {
            localScale.x = -localScale.x; 
            transform.localScale = localScale;
        }
    }

}
