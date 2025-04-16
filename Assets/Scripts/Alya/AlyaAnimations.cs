using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyaAnimations : MonoBehaviour {
    private Animator animator;

    // Start is called before the first frame update
    void Awake() {
        animator = GetComponent<Animator>();
    }

    // Public Animation Setters
    public void setBrake(Boolean isBraking) {
        animator.SetBool("Brake", isBraking);
    }

    public void setRun(Boolean isRunning) {
        animator.SetBool("Run", isRunning);
    }

    public void setIdle(Boolean isIdle) {
        animator.SetBool("Idle", isIdle);
    }

    public void setSnap(Boolean isSnapping) {
        animator.SetBool("Snap", isSnapping);
    }
}