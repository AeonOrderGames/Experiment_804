using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKick : MonoBehaviour {
    private LegMovement leg;

    private bool kickReady;

    private Collider2D box;

    // Use this for initialization
    void Start () {
		leg = FindObjectOfType<LegMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (kickReady && leg.kicking) {
            box.gameObject.GetComponent<Rigidbody2D>().mass = 2;
            box.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(leg.direction * 1.9f, 1.2f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if ((col.gameObject.name == "MetalBox1" || col.gameObject.name == "MetalBox2"))
        {
            box = col;
            kickReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if ((col.gameObject.name == "MetalBox1" || col.gameObject.name == "MetalBox2")) {
            box = col;
            kickReady = false;
        }
    }

}
