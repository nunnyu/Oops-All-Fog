using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlyaStateMachine : MonoBehaviour {
    // scripts
    public PlayerMovement playerMovement;
    public AlyaPicture alyaPicture;

    // states
    private enum PlayerState { Moving, TakingPicture, ChoosingAttack, Attacking }
    private PlayerState currentState;

    // Start is called before the first frame update
    void Start() {
        currentState = PlayerState.Moving;
    }

    // Update is called once per frame
    void Update() {
        HandleState();
    }

    // Handles the current player state 
    void HandleState() {
        switch (currentState) {
            case PlayerState.Moving:
                playerMovement.ProcessInputs(); 
                alyaPicture.ProcessInputs(); // if a picture input is taken, a request to change states occurs 
                break;

            case PlayerState.TakingPicture:
                break;
        }
    }

    void FixedUpdate() {
        if (currentState == PlayerState.Moving) {
            playerMovement.HandleMovement(); 
        }
    }
}
