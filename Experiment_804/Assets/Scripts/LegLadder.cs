using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegLadder : MonoBehaviour {

    public GameObject hand;
    public GameObject arm;

    private void OnTriggerEnter2D(Collider2D col) {
        if (arm != null && arm.activeSelf)
        {
            arm.GetComponent<PlayerArmMovement>().climbing = true;
            arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", true);
        }
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
            arm.GetComponent<PlayerArmMovement>().climbing = true;
            arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", true);
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
            arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", false);
            arm.GetComponent<Animator>().SetBool("ArmStanding", true);
        }
        
    }
}
