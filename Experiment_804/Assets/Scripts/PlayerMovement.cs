using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //Script in use
    private Animator animator;
    private Rigidbody2D rigidBody;
    //Speed of the player
    public float speed = 2;
    //How high the hand Jumps
    private float jumpForce = 2.5f;
    private bool grounded;

    // Use this for initialization
    void Awake () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
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
            transform.position = new Vector2(Mathf.Clamp(handPosition, -8f, 8f), transform.position.y);
        }
        //Set the float handWalking to the horizontal value
        animator.SetFloat("handWalking", Mathf.Abs(horizontal));

        //Checking if the Hand is jumping
        if(grounded && Input.GetKeyDown("w")) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //For the jumping Hand
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            grounded = true;
            animator.SetBool("HandJumping", !grounded);
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            grounded = false;
            animator.SetBool("HandJumping", !grounded);
        }
    }
}
