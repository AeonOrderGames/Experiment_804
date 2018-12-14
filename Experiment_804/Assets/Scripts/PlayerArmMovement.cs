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
    public bool pushing = false;
    public bool walking = false;
    public bool standing = false;
    public bool climbing = false;

    private LayerMask defaultLayer;
    private Rigidbody2D rigidBody;

    //private float climbVelocity;

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

        //Checking if the Arm is pushing
        if (Input.GetKeyDown("2")) {
            handCircleCollider.enabled = false;
            pushingArmCollider.SetActive(true);
            pushing = true;
            animator.SetBool("ArmPushing", true);
        }
         else if (Input.GetKeyUp("2")) {
            handCircleCollider.enabled = true;
            pushingArmCollider.SetActive(false);
            pushing = false;
            animator.SetBool("ArmPushing", false);
        }

        climbing = animator.GetBool("ArmClimbingIdle");
        //Checking if the Arm is standing up
        if (Input.GetKey("w") && !climbing) {
            animator.SetBool("ArmStanding", true);
            standingBoxCollider.SetActive(true);
            standing = true;
        }

        if (climbing && standing) {
            handCircleCollider.enabled = false;
            animator.SetBool("ArmClimbingIdle", true);
            rigidBody.gravityScale = 0f;

            if (Input.GetKey("w")) {
                animator.SetBool("ArmClimbing", true);
                animator.SetBool("ArmClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, (moveSpeed * 0.05f) * 1);
            }
            else if (Input.GetKey("s")) {
                animator.SetBool("ArmClimbing", true);
                animator.SetBool("ArmClimbingIdle", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, (moveSpeed * 0.05f) * -1);
            }
            else if (horizontal != 0) {
                animator.SetBool("ArmClimbing", true);
                animator.SetBool("ArmClimbingIdle", false);
            }
            else {
                animator.SetBool("ArmClimbingIdle", true);
                animator.SetBool("ArmClimbing", false);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            }
        }
        else {
            handCircleCollider.enabled = true;
            rigidBody.gravityScale = 1f;
            animator.SetBool("ArmClimbing", false);
            animator.SetBool("ArmClimbingIdle", false);
            climbing = false;
        }
        if (standing && (horizontal != 0.0f || Input.GetKey("a") || Input.GetKey("d"))) { 
            animator.SetBool("ArmStanding", false);
            standing = false;
            standingBoxCollider.SetActive(false);
        }
    }

    public void OnArmLanding() {
        standingBoxCollider.SetActive(false);
        handCircleCollider.enabled = true;
        climbing = false;
        standing = false;
        animator.SetBool("ArmStanding", false);
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, false);
    }
}
