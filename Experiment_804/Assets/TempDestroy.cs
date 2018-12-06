using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDestroy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Player_Foot"))
            Destroy(gameObject);
    }
}
