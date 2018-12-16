using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle2Trigger : MonoBehaviour {

    public GameObject plate1;
    public GameObject plate2;
    private AudioSource sound;
    private bool playingSound;
    private IEnumerator soundCoroutine;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        soundCoroutine = PlayAudio();
        transform.position = new Vector3(3.59f, 0.72f, 0f);

    }
	
	// Update is called once per frame
	void Update () {
        bool plate1On = plate1.GetComponent<PressurePlateTrigger>().pressurePlateOn;
        bool plate2On = plate2.GetComponent<PressurePlateTrigger>().pressurePlateOn;

        if (transform.position.y < 2.3f && plate1On && plate2On)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), 0);
            playingSound = true;
        }
        else if (transform.position.y > 0.72f && (!plate1On || !plate2On))
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y - 0.1f), 0);
            playingSound = true;
        }
        else {
            playingSound = false;
        }

        if(playingSound) {
            StartCoroutine(soundCoroutine);
        }
        else {
            StopCoroutine(soundCoroutine);
        }
    }

    private IEnumerator PlayAudio() {
        sound.Play();
        yield return new WaitForSeconds(1f);
        playingSound = false;
    }
}
