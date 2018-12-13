using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorOpen : MonoBehaviour {
    //take buttonCol out later
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    public GameObject nextLevelTrigger;
    public LegMovement Leg;
    public PlayerHandMovement Hand;
    public PlayerArmMovement Arm;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if ((Hand != null && Hand.Pushing && Leg.gameObject.activeSelf) || Arm.pushing) {
            sound.Play();
            animator.Play("ElevatorOpen");
            buttonCol.enabled = false;
            StartCoroutine(elevatorDelayTrigger());
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (Arm.pushing) {
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
