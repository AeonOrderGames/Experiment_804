using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFloor : MonoBehaviour {
    public GameObject hand;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        hand.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        hand.GetComponent<SpriteRenderer>().sortingOrder = 5;

    }
}
