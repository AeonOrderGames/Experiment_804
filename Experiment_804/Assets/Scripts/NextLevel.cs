using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    private bool handInDoor;
    private bool footInDoor;
    public int nextScene;
    private string[] sceneNames;


        public void Awake() {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(nextScene);
        sceneNames = new string[] {"Main", "Level_One" ,"Level_Two"};
        }

        private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Player_Hand") {
            var hand = FindObjectOfType<PlayerHandMovement>();
            hand.enabled = false;
            var handAnimator = hand.GetComponent<Animator>();
            handAnimator.SetBool("Jumping", false);
            handAnimator.SetFloat("HandWalking", 0);
            handAnimator.Play("Hand_Faded");
            Destroy(hand.gameObject, 1f);
            handInDoor = true;
        }

        if (col.gameObject.tag == "Player_Foot") {
            var foot = FindObjectOfType<PlayerFootMovement>();
            foot.enabled = false;
            foot.GetComponent<Animator>().Play("Foot_Faded");
            var footAnimator = foot.GetComponent<Animator>();
            footAnimator.SetBool("Jumping", false);
            footAnimator.SetFloat("FootWalking", 0);
            footAnimator.Play("Foot_Faded");
            Destroy(foot.gameObject, 1f);
            footInDoor = true;
        }

        if (footInDoor == true && handInDoor == true) {
            Initiate.Fade(sceneNames[nextScene], Color.black, 2f);
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
