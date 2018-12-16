using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class LegMovement : MonoBehaviour {

    private CharacterController2D controller;
    private Animator animator;

    public float moveSpeed = 40f;
    public float direction;
    private float horizontal;
    private bool jumping;
    public bool kicking;
    private PlayerHandMovement hand;
    private AudioSource sound;
    private GameObject climbCol;

    //private bool kick;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        hand = FindObjectOfType<PlayerHandMovement>();
        sound = GetComponent<AudioSource>();
    }

    private void Start() {
        if (gameObject.transform.Find("ClimbCollider").gameObject != null) {
            climbCol = gameObject.transform.Find("ClimbCollider").gameObject;
        }
        else {
            climbCol = null;
        }
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Player_Foot_Horizontal") * moveSpeed;
        if (horizontal != 0)
        {
            direction = Mathf.Sign(horizontal);
        }

        animator.SetFloat("LegWalking", Mathf.Abs(horizontal));

        if (Input.GetKeyDown("up")) {
            jumping = true;
            animator.SetBool("LegJumping", true);
            if (climbCol != null) climbCol.SetActive(false);
            if (hand != null) hand.climbing = false; //hand cant climb anymore
        }

        if (animator.GetBool("LegJumping") && Input.GetKeyDown("down")) {
            animator.SetBool("LegStomping", true);
            //animator.SetBool("LegJumping", false);
            sound.Play();
            //To shake the camera when the foot stomps
            CameraShaker.Instance.ShakeOnce(2f, 1f, .1f, 1f);
        }

        if (Input.GetKey(KeyCode.RightShift) && horizontal == 0)
        {
            kicking = true;
            animator.Play("Leg_Kick");
            //animator.SetBool("LegKicking", true);
        }
        else
        {
            kicking = false;
        }
    }

    public void OnLanding() {
        animator.SetBool("LegJumping", false);
        animator.SetBool("LegStomping", false);
        if (climbCol != null) climbCol.SetActive(true);
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
