using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootMovement : MonoBehaviour
{

    //Script in use
    private Animator animator;
    //Speed of the player
    public float speed;
    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Player_Foot_Horizontal");
        //Checking which direction the foot turns to
        if (horizontal > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        //Checking if the Foot is Walking
        if ((Input.GetKey("left") || Input.GetKey("right"))) {
            float footPosition = transform.position.x + horizontal * speed * Time.deltaTime;
            transform.position = new Vector2(Mathf.Clamp(footPosition, -8f, 8f), 0.3f);
        }
        //Set the float footWalking to the horizontal value
        animator.SetFloat("FootWalking", Mathf.Abs(horizontal));
    }
}
