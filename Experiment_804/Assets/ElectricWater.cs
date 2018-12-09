using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWater : MonoBehaviour {
    public bool electric;

	// Use this for initialization
	void Start () {
        electric = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Obsticle1")
        {
            electric = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Obsticle1")
        {
            electric = false;
        }
    }
}
