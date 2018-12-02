using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Script in use
    private Animator animator;

    //Speed of the player
    public float speed;
	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
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
        //Checking if the Hand is Walking
        if (Input.GetKey("a") || Input.GetKey("d")) {
            float handPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(Mathf.Clamp(handPosition, -8f, 8f), 0.3f);
        }
        //Set the float handWalking to the horizontal value
        animator.SetFloat("handWalking", Mathf.Abs(horizontal));
    }
}
