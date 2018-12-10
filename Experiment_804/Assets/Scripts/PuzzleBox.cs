using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour {

    private PlayerHandMovement Hand;
    private Rigidbody2D box;
    public GameObject foot;
    public GameObject leg;
    public GameObject boxStompCollider;
    public GameObject ShelfCollider;
    private AudioSource sound;


    private void Awake() {
        Hand = FindObjectOfType<PlayerHandMovement>();
        box = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    //If the player touches the box and is pushing with the hand, the box becomes easier to move
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Player_Hand") && Hand.Pushing == true) {
            box.mass = 2;
        }
    }

    //If the hand stops touching the box, it becomes heavy again.
    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player_Hand") || Hand.Pushing == false) {
            box.mass = 100;
        }
    }

    //If the hand is touching the box but is not pushing, then it becomes heavy again as well
    private void FixedUpdate() {
        if (!Hand.Pushing) {
            box.mass = 100;
        }
        //Checking if the foot is active
        if (boxStompCollider.activeSelf && boxStompCollider.GetComponent<ShelfStompTrigger>().footInsideTrigger) {

            if (foot != null && foot.activeSelf) {
                if (foot.GetComponent<Animator>().GetBool("FootStomping")) {
                    ShelfCollider.SetActive(false);
                }
            }

            else if (leg != null && leg.activeSelf) {
                if (leg.GetComponent<Animator>().GetBool("LegStomping")) {
                    Debug.Log("Leg is stompy");
                    ShelfCollider.SetActive(false);
                    StartCoroutine(setShelfActive());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Ground") {
            sound.Play();
        }
    }

    private IEnumerator setShelfActive() {
        yield return new WaitForSeconds(2f);
        ShelfCollider.SetActive(true);
    }
}
