using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class AlyaPicture : MonoBehaviour {
    public GameObject flash;
    private AlyaAnimations animations;
    private Boolean stateOn; // is Alya taking a picture? 

    // Start is called before the first frame update
    void Start() {
        animations = FindObjectOfType<AlyaAnimations>();
        animations.setSnap(false);
        flash.SetActive(false);
        stateOn = false;
    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(stateOn);
        // State machine handles this
    }

    // Put into update, processes inputs
    public void ProcessInputs() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateOn = true;
            animations.setSnap(true); // I animate it slightly before so it matches the flashing / hitbox
            Invoke("OnAttack", .2f);
        }  
    }
    // whenever you attack this happens 
    void OnAttack() {
        flash.SetActive(true); // this activates the parry hitbox 
        Invoke("OnAttackEnd", 0.05f);
    }

    // when the attack ends, this happnes
    void OnAttackEnd() {
        flash.SetActive(false);
        animations.setSnap(false);
        stateOn = false;
        Debug.Log("attack over.");
    }

    // returns whether or not the state is active
    public Boolean isActive() {
        return stateOn;
    }
}
