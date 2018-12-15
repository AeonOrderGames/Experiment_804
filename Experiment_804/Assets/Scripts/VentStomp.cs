using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentStomp : MonoBehaviour
{
    //private Rigidbody2D body;
    public GameObject foot;
    public GameObject ventOpen;
    private AudioSource sound;

    // Use this for initialization
    void Start()
    {
        //body = GetComponent<Rigidbody2D>();
        sound = ventOpen.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if foot is stomping 
        if (foot.GetComponent<Animator>().GetBool("FootStomping")) 
        {
            //play vent open sound
            sound.Play();

            //Set the vent open
            Instantiate(ventOpen, new Vector2(transform.position.x , -1.425f), Quaternion.identity);

            //Destroy the vent closed
            Destroy(gameObject);
        }

    }
}
