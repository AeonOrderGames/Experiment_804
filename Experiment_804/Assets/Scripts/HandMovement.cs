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

    private Rigidbody2D hand; //new code climb
    public float distance; //new code climb
    private float vertical; //new code climb
    private LayerMask legLadder; //new code climb
    private bool climbing; //new code climb


    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        hand = GetComponent<Rigidbody2D>(); //new code climb
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
