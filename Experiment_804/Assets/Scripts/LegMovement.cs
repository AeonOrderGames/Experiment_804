using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour {

    private CharacterController2D controller;
    private Animator animator;

    public float moveSpeed = 40f;

    private float horizontal;
    private bool jumping;
    private PlayerHandMovement hand;

    //private bool kick;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        hand = FindObjectOfType<PlayerHandMovement>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Player_Foot_Horizontal") * moveSpeed;

        animator.SetFloat("LegWalking", Mathf.Abs(horizontal));

        if (Input.GetKeyDown("up")) {
            jumping = true;
            animator.SetBool("LegJumping", true);
            this.gameObject.transform.Find("ClimbCollider").gameObject.SetActive(false); // no climbing collider
            hand.climbing = false; //hand cant climb anymore
        }

        if (animator.GetBool("LegJumping") && Input.GetKeyDown("down")) {
            animator.SetBool("LegStomping", true);
        }
    }

    public void OnLanding() {
        animator.SetBool("LegJumping", false);
        animator.SetBool("LegStomping", false);
        this.gameObject.transform.Find("ClimbCollider").gameObject.SetActive(true); //climbing collider goes back on
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }

    /*private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player_Hand" && Input.GetKey(KeyCode.W))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        }
        else if (col.tag == "Player_Hand" && Input.GetKey(KeyCode.S))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
        }
        else
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }*/
}
