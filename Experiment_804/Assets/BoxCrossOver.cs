using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCrossOver : MonoBehaviour {
    public GameObject crossBox;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "MetalBox") {
            crossBox.SetActive(true);
        }
    }
}
