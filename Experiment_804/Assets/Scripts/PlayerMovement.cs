using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Script in use
    private Animator animator;

    private Rigidbody2D rb2D;
    //Speed of the player
    public float speed;
	// Use this for initialization
	void Awake () {
        rb2D = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        //Checking if the Hand is Walking
        if (Input.GetKey("a") || Input.GetKey("d")) {
            float handPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(Mathf.Clamp(handPosition, -8f, 8f), 0.3f);
        }
        //Set the float handWalking to the horizontal value
        animator.SetFloat("handWalking", Mathf.Abs(horizontal));
    }
}
