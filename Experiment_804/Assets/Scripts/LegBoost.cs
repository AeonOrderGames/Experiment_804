using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegBoost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player_Hand")) {
            col.gameObject.GetComponent<Rigidbody2D>().mass = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player_Hand")) {
            col.gameObject.GetComponent<Rigidbody2D>().mass = 1f;
        }
    }
}
