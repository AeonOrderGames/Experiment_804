using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateLift : MonoBehaviour {

    private Animator animator;
    public PressurePlateTrigger plate;
    public AnimationClip objUp;
    public AnimationClip objDown;
    private bool wasUp;
    private float animTimer;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (plate.pressurePlateOn && animTimer > 1f) {
            animator.Play(objUp.name);
            wasUp = true;
            animTimer = 0;
        }
        else {
            if (wasUp && animTimer > 1f){
                animator.Play(objDown.name);
                animTimer = 0;
            }
        }

        animTimer += Time.deltaTime;
    }
}
