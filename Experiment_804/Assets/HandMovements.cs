using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovements : MonoBehaviour {

    private CharacterController2DHand controller;
    private Animator animator;

    //Speed of the player
    public float moveSpeed = 10f;
    public float direction;
    private float horizontal;

    //Hand pushing collider
    private CircleCollider2D handCircleCollider;
    public GameObject pushingHandCollider;

    //Hand pushing public variable referenced and used in puzzle box script
    public bool walking = false;
    public bool jumping = false;
    public bool pushing = false;
    public bool climbing = false;

    private LayerMask defaultLayer;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        controller = GetComponent<CharacterController2DHand>();
        animator = GetComponent<Animator>();
        handCircleCollider = GetComponent<CircleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        horizontal = Input.GetAxis("Player_Hand_Horizontal") * moveSpeed;
        if (horizontal != 0)
        {
            direction = Mathf.Sign(horizontal);
        }
        animator.SetFloat("HandWalking", Mathf.Abs(horizontal));

        //Check if the hand is pushing
        if (Input.GetKeyDown("2"))
        {
            handCircleCollider.enabled = false;
            pushingHandCollider.SetActive(true);
            pushing = true;
            animator.SetBool("HandPushing", true);
        }
        else if (Input.GetKeyUp("2"))
        {
            handCircleCollider.enabled = true;
            pushingHandCollider.SetActive(false);
            pushing = false;
            animator.SetBool("HandPushing", false);
        }

        if (Input.GetKeyDown("w") && !climbing)
        {
            jumping = true;
            animator.SetBool("HandJumping", true);
        }

        if (climbing)
        {
            rigidBody.gravityScale = 0f;

            if (Input.GetKey("w"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, (moveSpeed * 0.3f) * 1);
            }
            else if (Input.GetKey("s"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, (moveSpeed * 0.3f) * -1);
            }
            else if (horizontal != 0)
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
            }
            else
            {
                animator.SetBool("HandClimbingIdle", true);
                animator.SetBool("HandClimbingMoving", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            }
        }
        else
        {
            rigidBody.gravityScale = 1f;
            animator.SetBool("HandClimbingMoving", false);
            animator.SetBool("HandClimbingIdle", false);
        }
    }

    public void OnHandLanding()
    { 
        climbing = false;
        jumping = false;
        animator.SetBool("HandJumping", false);
    }

    private void LateUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}
