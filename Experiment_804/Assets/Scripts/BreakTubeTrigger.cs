using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTubeTrigger : MonoBehaviour {

    public GameObject brokenTube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        brokenTube.SetActive(true);

    }
}
