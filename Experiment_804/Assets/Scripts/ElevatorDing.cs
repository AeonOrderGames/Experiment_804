using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDing : MonoBehaviour {
    private AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        StartCoroutine(Ding());
    }

    private IEnumerator Ding()
    {
        yield return new WaitForSeconds(10.5f);
        sound.Play();
    }
}
