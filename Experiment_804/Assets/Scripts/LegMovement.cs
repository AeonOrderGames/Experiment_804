using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour {

    private CharacterController2D controller;
    private Animator animator;

    public float moveSpeed = 40f;

    private float horizontal;
    private bool jumping;
    //private bool kick;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Player_Foot_Horizontal") * moveSpeed;

        animator.SetFloat("LegWalking", Mathf.Abs(horizontal));

        if (Input.GetKeyDown("up")) {
            jumping = true;
            animator.SetBool("LegJumping", true);
        }

    }

    public void OnLanding() {
        animator.SetBool("LegJumping", false);
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}
