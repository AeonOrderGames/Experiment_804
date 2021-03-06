﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandMovement : MonoBehaviour
{
    //Script in use
    private Animator animator;
    private Rigidbody2D rigidBody;
    //Speed of the player
    public float speed = 2;
    //How high the hand Jumps
    public float jumpForce = 2f;
    public bool grounded;
    //Hand pushing collider
    private CircleCollider2D handCircleCollider;
    public GameObject handBoxCollider;
    //Hand pushing public variable referenced and used in puzzle box script
    public bool pushing;

    private LayerMask defaultLayer;

    //New code for climbing
    public bool climbing;
    private float climbVelocity;
    //New code for climbing

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        handCircleCollider = GetComponent<CircleCollider2D>();
        defaultLayer = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Player_Hand_Horizontal");
        //Checking which direction the hand turns to
        if (horizontal > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        //Checking if the Hand is pushing
        if (Input.GetKeyDown("2") && grounded) {
            handCircleCollider.enabled = false;
            handBoxCollider.SetActive(true);
            pushing = true;
            animator.SetBool("HandPushing", true);
        }
        else if (Input.GetKeyUp("2")) {
            handCircleCollider.enabled = true;
            handBoxCollider.SetActive(false);
            pushing = false;
            animator.SetBool("HandPushing", false);
        }

        //Checking if the Hand is Walking
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            float handPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(handPosition, transform.position.y);
        }
        //Set the float handWalking to the horizontal value
        animator.SetFloat("HandWalking", Mathf.Abs(horizontal));

        //Checking if the Hand is jumping
        if (grounded && Input.GetKeyDown("w"))
        {
            rigidBody.AddForce(Vector2.up * (jumpForce - 0.4f), ForceMode2D.Impulse);
        }

        //Limiting max jump velocity
        if (rigidBody.velocity.y > jumpForce)
        {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, 2.3f);
        }

        //Check if hand is not touching the DEFAULT layer
        if (!handCircleCollider.IsTouchingLayers(defaultLayer))
        {
            grounded = false;
            animator.SetBool("HandJumping", true);
        }

        if (climbing)
        {
            rigidBody.gravityScale = 0f;
            if (Input.GetKey("w"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, speed * 1);
            }
            else if (Input.GetKey("s"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, speed * -1);
            }
            else
            {
                animator.SetBool("HandClimbingIdle", true);
                animator.SetBool("HandClimbingMoving", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, speed * 0);
            }
        }

        else 
        {
            rigidBody.gravityScale = 1f;
            animator.SetBool("HandClimbingMoving", false);
            animator.SetBool("HandClimbingIdle", false);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player_Foot") || pushing)
        {
            grounded = true;
            animator.SetBool("HandJumping", !grounded);
        }
    }

    //Old jumping code
    /*
    //For the jumping Hand
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Grou stnd") || col.gameObject.CompareTag("Player_Foot")) {
            grounded = true;
            animator.SetBool("HandJumping", !grounded);
        }
    }
    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player_Foot")) {
            grounded = false;
            animator.SetBool("HandJumping", !grounded);
        }
    }
    */
}
