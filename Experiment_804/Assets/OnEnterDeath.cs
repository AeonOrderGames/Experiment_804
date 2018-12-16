using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterDeath : MonoBehaviour {

    public string levelName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col) {
        StartCoroutine(fadeTimer());
    }

    private IEnumerator fadeTimer() {
        yield return new WaitForSeconds(1f);
        Initiate.Fade(levelName, Color.black, 2f);
    }
}
