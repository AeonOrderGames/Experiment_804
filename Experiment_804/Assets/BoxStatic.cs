using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatic : MonoBehaviour
{
    //Should fix the problem so foot and hand cant push the box when walking towards it at the same time
    private Rigidbody2D box;
    public GameObject hand;
    public GameObject foot;

    private bool footOn = false;
    private bool handOn = false;
    // Use this for initialization
    void Start()
    {
        box = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if both hand and foot are touching the box and walking, the box should not move
        if (handOn && footOn)
        {
            if (hand.GetComponent<Animator>().GetFloat("HandWalking") > 0.01 && foot.GetComponent<Animator>().GetFloat("FootWalking") > 0.01)
            {
                box.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                box.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        else
        {
            box.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Check if hand is touching the box
        if (col.gameObject.CompareTag("Player_Hand"))
        {
            handOn = true;
        }
        //Check if foot is touching the box
        if (col.gameObject.CompareTag("Player_Foot"))
        {
            footOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        //Check if hand is not touching the box
        if (col.gameObject.CompareTag("Player_Hand"))
        {
            handOn = false;
        }
        //Check if foot is not touching the box
        if (col.gameObject.CompareTag("Player_Foot"))
        {
            footOn = false;
        }
    }
}
