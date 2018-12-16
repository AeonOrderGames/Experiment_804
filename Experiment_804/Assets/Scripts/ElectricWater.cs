using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWater : MonoBehaviour {
    private SpriteRenderer water;
    private Color flickerColor;
    public bool electric;
    private bool handDead = false;
    private bool footDead = false;
    private IEnumerator flickeringRoutine;
    private AudioSource sound;
    private bool handInElectric;
    private bool footInElectric;
    private Animator handAnimator;
    private Animator footAnimator;


    // Use this for initialization
    void Start() {
        electric = true;
        water = GetComponent<SpriteRenderer>();
        flickeringRoutine = flickeringElectric();
        flickerColor = new Color(0.4f, 1, 1, 1);
        sound = GetComponent<AudioSource>();
        handAnimator = FindObjectOfType<PlayerHandMovement>().gameObject.GetComponent<Animator>();
        footAnimator = FindObjectOfType<LegMovement>().gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if(electric) {
            if(handInElectric) {
                handAnimator.SetBool("HandDeath", true);
                handDead = true;
            }

            if(footInElectric) {
                footAnimator.Play("Leg_Death");
                footDead = true;
            }

            if (handDead || footDead) {
                StartCoroutine(fadeTimer());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Player_Hand")) {
            handInElectric = true;
        }
        else if (col.gameObject.CompareTag("Player_Foot")) {
            footInElectric = true;
        }


        if (col.gameObject.name == "Obsticle1") {
            electric = true;
            sound.Play();
            //Turn color of sprites yellow or start a cooroutine that flickers the colors
            StartCoroutine(flickeringRoutine);
        }

        if (electric) {
            
            if (col.gameObject.name == "Player_Leg") {
                col.gameObject.GetComponent<Animator>().Play("Leg_Death");
                footDead = true;
            }
            if (col.gameObject.name == "Player_Hand") {
                col.gameObject.GetComponent<Animator>().SetBool("HandDeath", true);
                handDead = true;
            }
            if (col.gameObject.name == "Player_Arm") {
                col.gameObject.GetComponent<Animator>().Play("Arm_Death");
                handDead = true;
            }
        } 

        if (handDead || footDead) {
            StartCoroutine(fadeTimer());
        }
    }


    private void OnTriggerExit2D(Collider2D col) {

        if (col.gameObject.CompareTag("Player_Hand")) {
            handInElectric = false;
        }
        else if (col.gameObject.CompareTag("Player_Foot")) {
            footInElectric = false;
        }

        if (col.gameObject.name == "Obsticle1") {
            electric = false;
            sound.Stop();
            //Put both sprite colors back to water or stop the cooroutine that runs the flickering yellow
            StopCoroutine(flickeringRoutine);
        }
    }

    private IEnumerator flickeringElectric() {
        while (true) {
            var randomFloat = Random.Range(0.1f, 0.4f);
            water.color = Color.white;
            yield return new WaitForSeconds(randomFloat);
            water.color = flickerColor;
            yield return new WaitForSeconds(randomFloat);
        }

    }

    private IEnumerator fadeTimer() {
        yield return new WaitForSeconds(1f);
        Initiate.Fade("Level_Two", Color.black, 2f);
    }
}
