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
    }

    private void Update()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (foot.GetComponent<Animator>().GetBool("FootStomping")) 
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            sound.Play();
            //StartCoroutine(delaySpawn());
        }

    }

    /*private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(0.15f);
        Instantiate(ventOpen, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }*/
}
