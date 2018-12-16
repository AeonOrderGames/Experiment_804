using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTubeTrigger : MonoBehaviour {

    public GameObject brokenTube;
    private LegMovement leg;
    private bool kickable;

    // Use this for initialization
    void Start () {
        leg = FindObjectOfType<LegMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		if(kickable && leg.kicking) {
            StartCoroutine(DelayBreak());
            kickable = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player_Foot"))
        {
            kickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player_Foot")) {
            kickable = false;
        }
    }

    private IEnumerator DelayBreak()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        brokenTube.SetActive(true);
        brokenTube.GetComponent<AudioSource>().Play();
    }
}
