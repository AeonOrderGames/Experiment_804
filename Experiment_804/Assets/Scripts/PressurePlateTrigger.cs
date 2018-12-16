using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour {

    public bool pressurePlateOn;
    public Sprite plateOn;
    private Sprite plateOff;

    // Use this for initialization
    void Start () {
        plateOff = GetComponent<SpriteRenderer>().sprite;
        pressurePlateOn = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name != "KickCollider") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = plateOn;
            pressurePlateOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name != "KickCollider") {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = plateOff;
            pressurePlateOn = false;
        }
    }

}
