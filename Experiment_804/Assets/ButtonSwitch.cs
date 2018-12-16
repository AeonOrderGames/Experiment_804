using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour {

    public GameObject obsticle1;
    public GameObject hand;
    public Sprite switchOn;
    public AnimationClip objUp;
    public AnimationClip objDown;
    private AudioSource sound;

    private PlayerArmMovement armScript;

    private void Awake() {
        armScript = hand.GetComponent<PlayerArmMovement>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (armScript != null) {
            if (armScript.pushing) {
                //Obsticle goes up and switch goes on.
                obsticle1.GetComponent<Animator>().Play(objUp.name);
                sound.Play();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
                Destroy(this);
            }
        }
    }
}
