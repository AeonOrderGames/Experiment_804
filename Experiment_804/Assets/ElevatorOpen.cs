using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour {
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    //public GameObject nextLevelTrigger;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player_Hand")
        {
            sound.Play();
            animator.Play("ElevatorOpen");
            buttonCol.enabled = false;
            //nextLevelTrigger.SetActive(true);
        }
    }
}
