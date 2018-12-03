using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private bool handInDoor;
    private bool footInDoor;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player_Hand")
        {
            handInDoor = true;
        }
        if (col.gameObject.tag == "Player_Foot")
        {
            footInDoor = true;
        }
        if (footInDoor == true && handInDoor == true)
        {
            Debug.Log("YAY YOU GET TO GO TO THE NEXT LEVEL!!!");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player_Hand")
        {
            handInDoor = false;
        }
        if (col.gameObject.tag == "Player_Foot")
        {
            footInDoor = false;
        }
    }
}
