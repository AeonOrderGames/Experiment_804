using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDestroy : MonoBehaviour {

   // public Canvas dialogCanvas;
    //public Level_1_Dialog dialogue;
    public GameObject hand;
    public GameObject arm;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player_Hand")) {
            gameObject.SetActive(false);
            //Freezing the screen
            //Time.timeScale = 0.0f;
            //dialogCanvas.gameObject.SetActive(true);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue() {
       // FindObjectOfType<Level_1_DialogManager>().StartDialogue(dialogue);
        hand.gameObject.SetActive(false);
        arm.gameObject.SetActive(true);
    }
}
