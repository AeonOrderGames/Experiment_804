using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTrigger : MonoBehaviour {

    void Awake() {
        StartCoroutine(timer());
    }

    private IEnumerator timer() {
        yield return new WaitForSeconds(29f);
        Initiate.Fade("Main_Menu", Color.black, 1f);
    }
}
