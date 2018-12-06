using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfStompTrigger : MonoBehaviour {

    public bool footInsideTrigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player_Foot")) {
            footInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            footInsideTrigger = false;
        }
    }
}
