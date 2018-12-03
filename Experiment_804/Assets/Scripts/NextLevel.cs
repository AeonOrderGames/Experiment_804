﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    private bool handInDoor;
    private bool footInDoor;


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
            footAnimator.SetFloat("HandWalking", 0);
            footAnimator.Play("Hand_Faded");
            Destroy(foot.gameObject, 1f);
            footInDoor = true;
        }

        if (footInDoor == true && handInDoor == true) {

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
