using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegLadder : MonoBehaviour {

    private PlayerHandMovement hand;
    private PlayerArmMovement arm;
	// Use this for initialization
	void Start () {
        hand = FindObjectOfType<PlayerHandMovement>();
        arm = FindObjectOfType<PlayerArmMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
         if(col.name == "Player_Hand")
        {
            hand.climbing = true; 
        }
        if (col.name == "Player_Arm")
        {
            arm.climbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Player_Hand")
        {
            hand.climbing = false;
        }
        if (col.name == "Player_Arm")
        {
            arm.climbing = false;
        }
    }
}
