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
        if (col.gameObject.name == "Player_Leg" && electric) 
        {
            col.gameObject.GetComponent<Animator>().Play("Leg_Death");
        }
        if (col.gameObject.name == "Player_Hand" && electric)
        {
            //col.gameObject.GetComponent<Animator>().Play("Hand_Death");
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
