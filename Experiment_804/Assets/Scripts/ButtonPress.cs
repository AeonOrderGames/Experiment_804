using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    public BoxCollider2D buttonCol;
    private Animator animator;
    public GameObject nextLevelTrigger;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player_Hand") {
            animator.Play("Door_Open");
            buttonCol.enabled = false;
            nextLevelTrigger.SetActive(true);
        }
    }
}
