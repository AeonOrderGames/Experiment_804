using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterPlaySound : MonoBehaviour {

    private AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        sound.Play();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        sound.Play();
    }
}
