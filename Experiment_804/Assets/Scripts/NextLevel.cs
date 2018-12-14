using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private bool handInDoor;
    private bool footInDoor;
    public int nextScene;
    private string[] sceneNames;

    public void Awake() {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        sceneNames = new string[] { "Main", "Level_One", "Elevator_One", "Level_Two","Elevator_Two", "Level_Three", "Credit_List"};
    }

    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Player_Hand") {
            var hand = FindObjectOfType<PlayerHandMovement>();
            var arm = FindObjectOfType<PlayerArmMovement>();

            if (hand != null) {
                hand.enabled = false;
                var handAnimator = hand.GetComponent<Animator>();
                handAnimator.SetBool("Jumping", false);
                handAnimator.SetFloat("HandWalking", 0);
                handAnimator.Play("Hand_Faded");
                Destroy(hand.gameObject, 1f);
                handInDoor = true;
            }
            else {
                arm.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                arm.enabled = false;
                var armAnimator = arm.GetComponent<Animator>();
                armAnimator.SetFloat("ArmWalking", 0);
                armAnimator.Play("Arm_Faded");
                Destroy(arm.gameObject, 1f);
                handInDoor = true;
            }

        }

        if (col.gameObject.tag == "Player_Foot") {

            var foot = FindObjectOfType<PlayerFootMovement>();
            var leg = FindObjectOfType<LegMovement>();

            if (foot != null) {
                foot.enabled = false;
                var footAnimator = foot.GetComponent<Animator>();
                footAnimator.SetBool("Jumping", false);
                footAnimator.SetFloat("FootWalking", 0);
                footAnimator.Play("Foot_Faded");
                Destroy(foot.gameObject, 1f);
                footInDoor = true;
            }

            else {
                leg.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                leg.enabled = false;
                var legAnimator = leg.GetComponent<Animator>();
                legAnimator.SetBool("LegJumping", false);
                legAnimator.SetFloat("LegWalking", 0);
                legAnimator.Play("Leg_Faded");
                Destroy(leg.gameObject, 1f);
                footInDoor = true;
            }

        }

        if (footInDoor && handInDoor) {
            if (nextScene == 9) {
                Initiate.Fade("Credit_List", Color.black, 2f);
            }
            else {
                Initiate.Fade(sceneNames[nextScene], Color.black, 2f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player_Hand") {
            handInDoor = false;
        }
        if (col.gameObject.tag == "Player_Foot") {
            footInDoor = false;
        }
    }
}