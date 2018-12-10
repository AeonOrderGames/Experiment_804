using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegKick : MonoBehaviour {
    private LegMovement leg;

	// Use this for initialization
	void Start () {
		leg = FindObjectOfType<LegMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);

        if ((col.gameObject.name == "MetalBox1" || col.gameObject.name == "MetalBox2") && leg.kicking)
        {
            Debug.Log("blob");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f ) * 10f, ForceMode2D.Impulse);
        }
    }

}
