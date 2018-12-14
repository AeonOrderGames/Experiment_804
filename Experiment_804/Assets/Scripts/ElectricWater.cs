using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWater : MonoBehaviour {
    private SpriteRenderer water;
    private Color flickerColor;
    public bool electric;
    private bool handDead = false;
    private bool footDead = false;
    private IEnumerator flickeringRoutine;

	// Use this for initialization
	void Start () {
        electric = true;
        water = GetComponent<SpriteRenderer>();
        flickeringRoutine = flickeringElectric();
        flickerColor = new Color(100, 255, 255, 255);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Obsticle1")
        {
            electric = true;
            //Turn color of sprites yellow or start a cooroutine that flickers the colors
            StartCoroutine(flickeringElectric());
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
            //Put both sprite colors back to water or stop the cooroutine that runs the flickering yellow
            StopCoroutine(flickeringRoutine);
        }
    }

    private IEnumerator flickeringElectric() {
        while (true) {
            var randomFloat = Random.Range(0.1f, 0.4f);
            water.color = Color.white;
            yield return new WaitForSeconds(randomFloat);
            water.color = new Color(0.4f, 1, 1, 1);
            yield return new WaitForSeconds(randomFloat);
        }

    }

    private IEnumerator fadeTimer() {
        yield return new WaitForSeconds(1f);
        Initiate.Fade("Level_2", Color.black, 2f);
    }
}
