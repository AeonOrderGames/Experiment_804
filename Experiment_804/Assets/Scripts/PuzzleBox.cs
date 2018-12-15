using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour {

   
    private Rigidbody2D box;
    private AudioSource sound;

    public GameObject foot;
    public GameObject leg;
    public GameObject hand;
    public GameObject arm;
    public GameObject boxStompCollider;
    public GameObject ShelfCollider;

    private float maxMass = 1000f;
    private float minMass = 2;

    private bool soundOn = false;
    private bool stompOnce = false;

    public bool footOn = false;
    public bool handOn = false;


    private void Awake() {
        box = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    //If the player touches the box and is pushing with the hand, the box becomes easier to move
    private void OnCollisionEnter2D(Collision2D col) {


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

        if (hand != null && hand.activeSelf)
        {
            if (col.gameObject.CompareTag("Player_Hand") && hand.GetComponent<Animator>().GetBool("HandPushing"))
            {
                box.mass = minMass;
            }
        }

        if (arm != null && arm.activeSelf)
        {
            if (col.gameObject.CompareTag("Player_Hand") && arm.GetComponent<Animator>().GetBool("ArmPushing"))
            {
                box.mass = minMass;
            }
        }

    }

    //If the hand stops touching the box, it becomes heavy again.
    private void OnCollisionExit2D(Collision2D col) {

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

        if (hand != null && hand.activeSelf)
        {
            if (col.gameObject.CompareTag("Player_Hand") && !hand.GetComponent<Animator>().GetBool("HandPushing"))
            {
                box.mass = maxMass;
            }
        }

        if (arm != null && arm.activeSelf)
        {
            if (col.gameObject.CompareTag("Player_Hand") && !arm.GetComponent<Animator>().GetBool("ArmPushing"))
            {
                box.mass = maxMass;
            }
        }
    }


    private void FixedUpdate() {

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

        //If the hand is touching the box but is not pushing, then it should be heavy
        if (hand != null && hand.activeSelf)
        {
            if (!hand.GetComponent<Animator>().GetBool("HandPushing")) {
                box.mass = maxMass;
            }
        }

        //If the arm is touching the box but is not pushing, then it should be heavy
        if (arm != null && arm.activeSelf)
        {
            if (!arm.GetComponent<Animator>().GetBool("ArmPushing")) {
                box.mass = maxMass;
            }
        }

        //Checking if the foot is active
        if (boxStompCollider.activeSelf && boxStompCollider.GetComponent<ShelfStompTrigger>().footInsideTrigger) {

            if (foot != null && foot.activeSelf) {
                if (foot.GetComponent<Animator>().GetBool("FootStomping")) {
                    ShelfCollider.SetActive(false);
                    //if foot has never stomped with that box, sound can go on
                    if (!stompOnce)
                    {
                        soundOn = true;
                        stompOnce = true;
                    }
                }
            }

            else if (leg != null && leg.activeSelf) {
                if (leg.GetComponent<Animator>().GetBool("LegStomping")) {
                    ShelfCollider.SetActive(false);
                    StartCoroutine(setShelfActive());
                    //if leg has never stomped with that box, sound can go on
                    if (!stompOnce)
                    {
                        soundOn = true;
                        stompOnce = true;
                    }
                 
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Ground" && soundOn) {
            sound.Play();
            box.mass = maxMass;
            soundOn = false;
        }
    }

    private IEnumerator setShelfActive() {
        yield return new WaitForSeconds(0.5f);
        ShelfCollider.SetActive(true);
    }
}
