using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnPressure : MonoBehaviour {

    public PressurePlateTrigger plate;
    public float highPos;
    public float minPos;
    private float inbetweenTimer;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(plate.pressurePlateOn) {
            if(transform.position.y <= highPos) {
                transform.position += new Vector3(0, Time.deltaTime, 0);
            }
        }
        else {
            if (transform.position.y >= minPos) {
                transform.position -= new Vector3(0, Time.deltaTime, 0);
            }
        }
	}
}
