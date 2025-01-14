using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Keira Stats")]
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
    }

    void Move() {
        Vector2 targetVelocity = new Vector2(targetVector.x * speedX, targetVector.y * speedY);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, slidingFactor);
    }
}
