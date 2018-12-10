using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_DialogueTrigger : MonoBehaviour {

    public Canvas DialogueCanvas;
    public Level_1_Dialog dialogue;
    private Level_1_DialogManager dialogueManager;
    private bool done;

    private void Awake() {
        done = false;
        dialogueManager = FindObjectOfType<Level_1_DialogManager>();
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(!done) {
            DialogueCanvas.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            dialogueManager.StartDialogue(dialogue);
            done = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        Destroy(gameObject);
    }
}