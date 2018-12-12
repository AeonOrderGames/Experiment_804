using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmMovement : MonoBehaviour {

    //Script in use
    private CharacterController2D controller;
    private Animator animator;

    //Speed of the player
    public float moveSpeed = 20f;
    public float direction;
    private float horizontal;
    //Hand/Arm pushing collider
    private CircleCollider2D handCircleCollider;
    public GameObject pushingArmCollider;
    public GameObject standingBoxCollider;
    //Hand pushing public variable referenced and used in puzzle box script
    public bool Pushing = false;
    public bool Walking = false;
    public bool Standing = false;

    private LayerMask defaultLayer;
    private Rigidbody2D rigidBody;

    public bool climbing;
    private float climbVelocity;

    // Use this for initialization
    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        handCircleCollider = GetComponent<CircleCollider2D>();
        //defaultLayer = LayerMask.GetMask("Default")
        rigidBody = GetComponent<Rigidbody2D>();
}

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Player_Hand_Horizontal") * moveSpeed;
        if (horizontal != 0) {
            direction = Mathf.Sign(horizontal);
        }
        
        animator.SetFloat("ArmWalking", Mathf.Abs(horizontal));
        if(Mathf.Abs(horizontal) < 0.01) {
            Walking = false;
        }
        else {
            Walking = true;
        }

        //Checking if the Arm is pushing
        if (Input.GetKeyDown("2")) {
            handCircleCollider.enabled = false;
            pushingArmCollider.SetActive(true);
            Pushing = true;
            animator.SetBool("ArmPushing", true);
        }
        else if (Input.GetKeyUp("2")) {
            handCircleCollider.enabled = true;
            pushingArmCollider.SetActive(false);
            Pushing = false;
            animator.SetBool("ArmPushing", false);
        }

        //Checking if the Arm is standing up
        if (Input.GetKey("w")) {
            animator.SetBool("ArmStanding", true);
            standingBoxCollider.SetActive(true);
            Standing = true;
        }
        if(Walking) {
            animator.SetBool("ArmStanding", false);
            standingBoxCollider.SetActive(false);
            Standing = false;
        }

        //
        if (climbing)
        {
            rigidBody.gravityScale = 0f;
            if (Input.GetKey("w"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, moveSpeed * 1);
            }
            else if (Input.GetKey("s"))
            {
                animator.SetBool("HandClimbingMoving", true);
                animator.SetBool("HandClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, moveSpeed * -1);
            }
            else
            {
                animator.SetBool("HandClimbingIdle", true);
                animator.SetBool("HandClimbingMoving", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, moveSpeed * 0);
            }
        }

        else
        {
            rigidBody.gravityScale = 1f;
            animator.SetBool("HandClimbingMoving", false);
            animator.SetBool("HandClimbingIdle", false);
        }
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, false);
    }
}
