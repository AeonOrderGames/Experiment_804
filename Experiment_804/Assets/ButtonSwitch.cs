using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour {

    public GameObject obsticle1;
    public GameObject hand;
    public Sprite switchOn;
    private Sprite switchOff;
    public AnimationClip objUp;
    public AnimationClip objDown;

    private PlayerArmMovement armScript;

    private void Awake() {
        armScript = hand.GetComponent<PlayerArmMovement>();
    }

    // Use this for initialization
    void Start() {
        switchOff = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (armScript != null) {
            if (armScript.pushing) {
                //Obsticle goes up and switch goes on.
                obsticle1.GetComponent<Animator>().Play(objUp.name);
      
                this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
            }
        }
    }
}
