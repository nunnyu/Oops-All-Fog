using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlyaPicture : MonoBehaviour {
    public GameObject flash;
    public static event Action OnAttackStarted; 
    #region TODO ^^^
    #endregion

    // Start is called before the first frame update
    void Start() {
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        // State machine handles this 
    }

    // Put into update, processes inputs 
    public void ProcessInputs() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnAttack();
        }  
    }
    // whenever you attack this happens 
    void OnAttack() {
        flash.SetActive(true); // this activates the parry hitbox  
        Invoke("OnAttackEnd", 0.2f);
    }

    // when the attack ends, this happnes
    void OnAttackEnd() {
        flash.SetActive(false);
        Debug.Log("attack over.");
    }
}
