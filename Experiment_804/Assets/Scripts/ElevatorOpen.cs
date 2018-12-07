using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour {
    public BoxCollider2D buttonCol;
    private Animator animator;
    private AudioSource sound;
    public GameObject nextLevelTrigger;

    private void Awake() {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GameObject.FindGameObjectWithTag("Player_Hand").GetComponentInChildren<BoxCollider2D>().name.Equals(col.name))
        {
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
