using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour {

    private PlayerHandMovement Hand;
    private Rigidbody2D box;
    public GameObject foot;
    public GameObject boxStompCollider;
    public GameObject ShelfCollider;


    private void Awake() {
        Hand = FindObjectOfType<PlayerHandMovement>();
        box = GetComponent<Rigidbody2D>();
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
        if(!Hand.Pushing) {
            box.mass = 100;
        }
        if (foot.GetComponent<Animator>().GetBool("FootStomping")
            && boxStompCollider.activeSelf
            && boxStompCollider.GetComponent<ShelfStompTrigger>().footInsideTrigger)
        {
            boxStompCollider.SetActive(false);
            ShelfCollider.SetActive(false);
        }
    }
}
