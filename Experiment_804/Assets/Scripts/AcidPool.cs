using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour {
    private bool armDead = false;
    private bool legDead = false;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player_Leg") {
            col.gameObject.GetComponent<Animator>().Play("Leg_Death");
            legDead = true;
        }
        if (col.gameObject.name == "Player_Arm") {
            col.gameObject.GetComponent<Animator>().Play("Arm_Dying");
            armDead = true;
        }
        if (armDead || legDead) {
            StartCoroutine(fadeTimer());
        }
    }

    private IEnumerator fadeTimer() {
        yield return new WaitForSeconds(1f);
        Initiate.Fade("Level_Three", Color.black, 2f);
    }



}
