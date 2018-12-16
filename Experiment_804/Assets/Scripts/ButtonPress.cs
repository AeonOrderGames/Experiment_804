using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    public GameObject nextLevelTrigger;
    private PlayerHandMovement hand;
    private PlayerArmMovement arm;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        hand = FindObjectOfType<PlayerHandMovement>();
        arm = FindObjectOfType<PlayerArmMovement>();
    }


    private void OnTriggerEnter2D(Collider2D col) {
        if ((hand != null && hand.pushing) || (arm != null && arm.pushing)) {
            if(col.gameObject.CompareTag("Player_Hand")) {
                animator.Play("Door_Open");
                sound.Play();
                buttonCol.enabled = false;
                nextLevelTrigger.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if ((hand != null && hand.pushing) || (arm != null && arm.pushing)) {
            if (col.gameObject.CompareTag("Player_Hand")) {
                animator.Play("Door_Open");
                sound.Play();
                buttonCol.enabled = false;
                nextLevelTrigger.SetActive(true);
            }
        }
    }
}
