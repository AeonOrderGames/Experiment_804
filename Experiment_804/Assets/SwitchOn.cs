using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOn : MonoBehaviour {

	public GameObject obsticle1;
    public GameObject hand;
    public Sprite switchOn;
    private Sprite switchOff;
    

	// Use this for initialization
	void Start () {
        switchOff = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    { 
        if (hand.GetComponent<PlayerHandMovement>().Pushing)
        {
            //Obsticle goes up and switch goes on.
            obsticle1.GetComponent<Animator>().Play("Obsticle1Up");

            this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
            //wait 
            StartCoroutine(Obsticle1Timer());
        }
    }

    private IEnumerator Obsticle1Timer()
    {
        yield return new WaitForSeconds(10f);
        //Obsticle goes down and switch goes off
        obsticle1.GetComponent<Animator>().Play("Obsticle1Down");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = switchOff;
    }
}
