using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextRoom : MonoBehaviour {

    private bool handInDoor;
    private bool footInDoor;
    public int nextScene;

    // Use this for initialization
    void Start() {
        nextScene = SceneManager.GetActiveScene().buildIndex;
    }


    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Player_Hand") {
            var arm = FindObjectOfType<PlayerArmMovement>();
            arm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            arm.enabled = false;
            var armAnimator = arm.GetComponent<Animator>();
            armAnimator.SetFloat("ArmWalking", 0);
            armAnimator.Play("Arm_Faded");
            Destroy(arm.gameObject, 1f);
            handInDoor = true;
        }

        if (col.gameObject.tag == "Player_Foot") {
            var leg = FindObjectOfType<LegMovement>();
            leg.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            leg.enabled = false;
            var legAnimator = leg.GetComponent<Animator>();
            legAnimator.SetBool("LegJumping", false);
            legAnimator.SetFloat("LegWalking", 0);
            legAnimator.Play("Leg_Faded");
            Destroy(leg.gameObject, 1f);
            footInDoor = true;
        }

        if (footInDoor && handInDoor) {
            if(nextScene == 8) {
                Initiate.Fade("Level_Three_Room", Color.black, 2f);
            }
            else {
                Initiate.Fade("Scientist_Room", Color.black, 2f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player_Hand") {
            handInDoor = false;
        }
        if (col.gameObject.tag == "Player_Foot") {
            footInDoor = false;
        }
    }
}
