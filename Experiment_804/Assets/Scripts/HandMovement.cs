using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    private CharacterController2D controller;
    private Animator animator;

    public float moveSpeed = 40f;

    private float horizontal;
    private bool jumping; //Jumping and pushing will need to be public if we implement this script into production
    private bool pushing;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update () {
        horizontal = Input.GetAxisRaw("Player_Hand_Horizontal") * moveSpeed;

        animator.SetFloat("HandWalking", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Hand_Jump")) {
            jumping = true;
            animator.SetBool("HandJumping", true);
        }

        if(Input.GetKeyDown("2")) {
            pushing = true;
        }
	}

    public void OnLanding() {
        animator.SetBool("HandJumping", false);
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jumping);
        jumping = false;
        pushing = false;
    }
}
