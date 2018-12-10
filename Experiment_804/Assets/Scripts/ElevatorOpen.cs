using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour {
    //take buttonCol out later
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    public GameObject nextLevelTrigger;
    public LegMovement Leg;
    public PlayerHandMovement Hand;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log(Leg.enabled);
        if (Hand.Pushing && Leg.gameObject.activeSelf) {
            sound.Play();
            animator.Play("ElevatorOpen");
            buttonCol.enabled = false;
            StartCoroutine(elevatorDelayTrigger());
        }
    }

    private IEnumerator elevatorDelayTrigger() {
        yield return new WaitForSeconds(5f);
        nextLevelTrigger.SetActive(true);
       
    }
}
