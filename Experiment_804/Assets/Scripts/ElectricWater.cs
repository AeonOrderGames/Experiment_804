using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWater : MonoBehaviour {
    public bool electric;
    private bool handDead = false;
    private bool footDead = false;
    private InteractableShine shine;

	// Use this for initialization
	void Start () {
        electric = true;
        shine = GetComponent<InteractableShine>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Obsticle1")
        {
            electric = true;
        }
        if (col.gameObject.name == "Player_Leg" && electric) 
        {
            col.gameObject.GetComponent<Animator>().Play("Leg_Death");
            footDead = true;
        }
        if (col.gameObject.name == "Player_Hand" && electric)
        {
            col.gameObject.GetComponent<Animator>().Play("Hand_Death");
            handDead = true;
        }
        if(handDead || footDead) {
            StartCoroutine(fadeTimer());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Obsticle1")
        {
            electric = false;
            shine.enabled = false;
        }
    }

    private IEnumerator fadeTimer() {
        yield return new WaitForSeconds(1f);
        Initiate.Fade("Level_2", Color.black, 2f);
    }
}
