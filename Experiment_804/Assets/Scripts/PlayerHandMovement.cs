using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandMovement : MonoBehaviour {
    //Script in use
    private Animator animator;
    private Rigidbody2D rigidBody;
    //Speed of the player
    public float speed = 2;
    //How high the hand Jumps
    public float jumpForce = 2.5f;
    public bool grounded;
    //Hand pushing collider
    private CircleCollider2D handCircleCollider;
    public GameObject handBoxCollider;
    //Hand pushing public variable referenced and used in puzzle box script
    public bool Pushing;


    // Use this for initialization
    void Awake() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        handCircleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float horizontal = Input.GetAxis("Player_Hand_Horizontal");
        //Checking which direction the hand turns to
        if (horizontal > 0 && transform.localScale.x < 0) {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontal < 0 && transform.localScale.x > 0) {
            transform.localScale = new Vector2(-1, 1);
        }
        //Checking if the Hand is Walking
        if (Input.GetKey("a") || Input.GetKey("d")) {
            float handPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(handPosition, transform.position.y);
        }
        //Set the float handWalking to the horizontal value
        animator.SetFloat("HandWalking", Mathf.Abs(horizontal));

        //Checking if the Hand is jumping
        if (grounded && Input.GetKeyDown("w")) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        //Limiting max jump velocity
        if (rigidBody.velocity.y > jumpForce) {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, 3.0f);
        }

        //Checking if the Hand is pushing
        if (Input.GetKeyDown("f")) {
            handCircleCollider.enabled = false;
            handBoxCollider.SetActive(true);
            Pushing = true;
            animator.SetBool("HandPushing", true);
        }
        else if (Input.GetKeyUp("f")) {
            handCircleCollider.enabled = true;
            handBoxCollider.SetActive(false);
            Pushing = false;
            animator.SetBool("HandPushing", false);
        }

        //Check if hand is not touching layer 0 at all
        if(handCircleCollider.IsTouchingLayers(-1)) {
            grounded = true;
            animator.SetBool("HandJumping", false);
        }
    }

    private void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player_Foot")) {
            grounded = true;
            animator.SetBool("HandJumping", !grounded);
        }
    }

    //Old jumping code
    /*
    //For the jumping Hand
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player_Foot")) {
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
