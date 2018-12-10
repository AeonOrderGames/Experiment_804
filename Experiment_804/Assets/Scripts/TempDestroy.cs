using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDestroy : MonoBehaviour {

    public Canvas dialogCanvas;
    public Level_1_Dialog dialogue;
    public GameObject foot;
    public GameObject leg;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player_Foot")) {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //Freezing the screen
            Time.timeScale = 0.0f;
            dialogCanvas.gameObject.SetActive(true);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue() {
        FindObjectOfType<Level_1_DialogManager>().StartDialogue(dialogue);
        foot.gameObject.SetActive(false);
        leg.gameObject.SetActive(true);
    }
}
