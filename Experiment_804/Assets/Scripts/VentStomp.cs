using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentStomp : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject foot;
    public GameObject ventOpen;
    private AudioSource sound;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (foot.GetComponent<Animator>().GetBool("FootStomping")) 
        {
            Instantiate(ventOpen, new Vector2(transform.position.x , -1.425f), Quaternion.identity);
            
            //body.bodyType = RigidbodyType2D.Dynamic;
            sound.Play();
            //StartCoroutine(delaySpawn());
            Destroy(gameObject);
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")) {
            StartCoroutine(delayedStatic());       
        }
    }

    private IEnumerator delayedStatic()
    {
        yield return new WaitForSeconds(1f);
        body.bodyType = RigidbodyType2D.Static;
    }
    */
}
