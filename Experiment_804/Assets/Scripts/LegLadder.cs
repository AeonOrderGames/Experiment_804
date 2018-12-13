using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegLadder : MonoBehaviour {

    public GameObject hand;
    public GameObject arm;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (hand != null && hand.activeSelf)
        {
            hand.GetComponent<Animator>().SetBool("HandClimbingIdle", true);
            hand.GetComponent<PlayerHandMovement>().climbing = true;
        }

        if (arm != null && arm.activeSelf)
        {
            //Debug.Log("Blobby in");
            arm.GetComponent<PlayerArmMovement>().climbing = true;
            //arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", true);
            //Debug.Log(arm.GetComponent<Animator>().GetBool("ArmClimbingIdle"));
            //Debug.Log(arm.GetComponent<Animator>().GetBool("ArmStanding"));
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
       
        if (hand != null && hand.activeSelf)
        {
            hand.GetComponent<Animator>().SetBool("HandClimbingIdle", false);
            hand.GetComponent<PlayerHandMovement>().climbing = false;
        }

        if (arm != null && arm.activeSelf)
        {
            arm.GetComponent<PlayerArmMovement>().climbing = false;
            //arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", false);
            //arm.GetComponent<Animator>().SetBool("ArmStanding", true);
            //Debug.Log("Blobby out");
        }
        
    }
}
