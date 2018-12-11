using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmMovement : MonoBehaviour {

    //Script in use
    private CharacterController2D controller;
    private Animator animator;

    //Speed of the player
    public float moveSpeed = 40f;
    public float direction;
    private float horizontal;
    //Hand/Arm pushing collider
    private CircleCollider2D handCircleCollider;
    public GameObject handBoxCollider;
    //Hand pushing public variable referenced and used in puzzle box script
    public bool Pushing;

    private LayerMask defaultLayer;

    // Use this for initialization
    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        handCircleCollider = GetComponent<CircleCollider2D>();
        //defaultLayer = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Player_Hand_Horizontal") * moveSpeed;
        if (horizontal != 0) {
            direction = Mathf.Sign(horizontal);
        }

        animator.SetFloat("ArmWalking", Mathf.Abs(horizontal));


        //Checking if the Arm is pushing
        /*if (Input.GetKeyDown("2")) {
            handCircleCollider.enabled = false;
            handBoxCollider.SetActive(true);
            Pushing = true;
            animator.SetBool("ArmPushing", true);
        }
        else if (Input.GetKeyUp("2")) {
            handCircleCollider.enabled = true;
            handBoxCollider.SetActive(false);
            Pushing = false;
            animator.SetBool("ArmPushing", false);
        }*/
    }

    private void FixedUpdate() {
        controller.Move(horizontal * Time.fixedDeltaTime, false, false);
    }
}
