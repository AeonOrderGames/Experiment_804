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
        }

        if (arm != null && arm.activeSelf)
        {
            Debug.Log("Blobby in");
            arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", true);
            Debug.Log(arm.GetComponent<Animator>().GetBool("ArmClimbingIdle"));
            Debug.Log(arm.GetComponent<Animator>().GetBool("ArmStanding"));
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
       
        if (hand != null && hand.activeSelf)
        {
            hand.GetComponent<Animator>().SetBool("HandClimbingIdle", false);
        }

        if (arm != null && arm.activeSelf)
        {
            arm.GetComponent<Animator>().SetBool("ArmClimbingIdle", false);
            Debug.Log("Blobby out");
        }
        
    }
}
