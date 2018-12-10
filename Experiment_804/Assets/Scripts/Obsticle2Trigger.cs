using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle2Trigger : MonoBehaviour {

    public GameObject plate1;
    public GameObject plate2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        bool plate1On = plate1.GetComponent<PressurePlateTrigger>().pressurePlateOn;
        bool plate2On = plate2.GetComponent<PressurePlateTrigger>().pressurePlateOn;

        if (transform.position.y < 2.3 && plate1On && plate2On)
        {
           transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), 0);
        }

        else if (transform.position.y > 0.4 && (!plate1On || !plate2On))
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y - 0.1f), 0);
        }
    }
}
