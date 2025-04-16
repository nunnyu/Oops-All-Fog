using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    private AlyaAnimations animations;
    private float cameraSlideFactor = 1.15f;

    // flags
    bool hasBraked; // this is to help with animation
    
    private Vector2 targetVector; // This is the final calculated value for desired direction and speed

    // Start is called before the first frame update
    void Start() {
        animations = FindObjectOfType<AlyaAnimations>();
        if (animations == null) Debug.LogError("AlyaAnimations component not found.");
    }

    // Update is called once per frame
    void Update() {
        // ProcessInputs();
        // we do this in the state machine now 
    }

    void FixedUpdate() {
        // Move();
        // we do this in the state machine now 
    }

    // Params: takes in the X input and Y input 
    // Does all of the animation work related to Alya's movement
    void processAnimations(float inputX, float inputY) {
        Boolean inputDetected = Math.Abs(inputX) > 0f || Math.Abs(inputY) > 0f;

        if (inputDetected) {
            animations.setRun(true);
            animations.setBrake(false);
            animations.setIdle(false);

            hasBraked = false;
        } else {
            if (!hasBraked) {
                animations.setRun(false);
                animations.setBrake(true);
                animations.setIdle(false);

                hasBraked = true;
            } else {
                animations.setRun(false);
                animations.setBrake(false);
                animations.setIdle(true);
            }
        }
    }

    // Detects inputs and executes functions
    public void ProcessInputs() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        targetVector = new Vector2(x, y).normalized;

        if (x > 0) {
            Flip(true);
        } else if (x < 0) {
            Flip(false);
        } 

        // Processes animations at the end; after inputs are given
        processAnimations(x, y);
    }

    public void halt() {
        this.rb.velocity = this.rb.velocity / cameraSlideFactor;
        Debug.Log(this.rb.velocity);
        this.rb.angularVelocity = 0f;
    }

    public void HandleMovement() {
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