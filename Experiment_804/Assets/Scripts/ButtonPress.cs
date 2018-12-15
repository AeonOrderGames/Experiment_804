using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    public GameObject nextLevelTrigger;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D col) {
        if (GameObject.FindGameObjectWithTag("Player_Hand").GetComponentInChildren<BoxCollider2D>().name.Equals(col.name)) {
            animator.Play("Door_Open");
            sound.Play();
            buttonCol.enabled = false;
            nextLevelTrigger.SetActive(true); 
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (GameObject.FindGameObjectWithTag("Player_Hand").GetComponentInChildren<BoxCollider2D>().name.Equals(col.name)) {
            animator.Play("Door_Open");
            sound.Play();
            buttonCol.enabled = false;
            nextLevelTrigger.SetActive(true);
        }
    }
}
