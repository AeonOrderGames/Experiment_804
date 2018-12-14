using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTubeTrigger : MonoBehaviour {

    public GameObject brokenTube;
    private LegMovement leg;

	// Use this for initialization
	void Start () {
        leg = FindObjectOfType<LegMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Player_Leg" && leg.kicking)
        {
            StartCoroutine(DelayBreak());
        }
    }

    private IEnumerator DelayBreak()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        brokenTube.SetActive(true);
    }
}
