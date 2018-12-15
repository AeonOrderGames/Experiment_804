using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOn : MonoBehaviour {

    public GameObject obsticle1;
    public GameObject hand;
    public Sprite switchOn;
    private Sprite switchOff;
    public AnimationClip objUp;
    public AnimationClip objDown;

    private PlayerArmMovement armScript;
    private PlayerHandMovement handScript;

    private void Awake() {
        armScript = hand.GetComponent<PlayerArmMovement>();
        handScript = hand.GetComponent<PlayerHandMovement>();
    }

    // Use this for initialization
    void Start()
    {
        switchOff = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(handScript == null) {
            if (armScript.pushing) {
                //Obsticle goes up and switch goes on.
                obsticle1.GetComponent<Animator>().Play(objUp.name);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
                StartCoroutine(Obsticle1Timer());
            }
        }
        else {
            if (handScript.pushing) {
                //Obsticle goes up and switch goes on.
                obsticle1.GetComponent<Animator>().Play(objUp.name);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
                StartCoroutine(Obsticle1Timer());
            }
        }
    }


    private IEnumerator Obsticle1Timer()
    {
        yield return new WaitForSeconds(10f);
        //Obsticle goes down and switch goes off
        obsticle1.GetComponent<Animator>().Play(objDown.name);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOff;
    }
}
