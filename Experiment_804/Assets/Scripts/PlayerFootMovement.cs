using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootMovement : MonoBehaviour {
    //Script in use
    private Animator animator;
    private Rigidbody2D rigidBody;
    //Speed of the player
    public float speed = 1;
    //How high the hand Jumps
    public float jumpForce = 3.5f;
    private bool grounded;

    // Use this for initialization
    void Awake() {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxis("Player_Foot_Horizontal");
        //Checking which direction the foot turns to
        if (horizontal > 0 && transform.localScale.x < 0) {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontal < 0 && transform.localScale.x > 0) {
            transform.localScale = new Vector2(-1, 1);
        }
        //Checking if the Foot is Walking
        if ((Input.GetKey("left") || Input.GetKey("right"))) {
            float footPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(footPosition, transform.position.y);
        }
        //Set the float footWalking to the horizontal value
        animator.SetFloat("FootWalking", Mathf.Abs(horizontal));

        //Checking if the Foot is jumping
        if (grounded && Input.GetKeyDown("up")) {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Checking if the Foot is stomping
        if (animator.GetBool("FootJumping") && Input.GetKey("m")) {
            animator.SetBool("FootJumping", false);
            animator.SetBool("FootStomping", true);
            rigidBody.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
        else if (grounded && !animator.GetBool("FootJumping")) {
            animator.SetBool("FootStomping", false);

        }
    }

    //For the jumping Hand
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            grounded = true;
            animator.SetBool("FootJumping", !grounded);
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            grounded = false;
            //Foot stomping
            animator.SetBool("FootJumping", !grounded);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("FootJumping", !grounded);
        }
    }
}
