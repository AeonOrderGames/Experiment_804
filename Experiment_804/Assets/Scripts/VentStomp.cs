using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentStomp : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject foot;
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (foot.GetComponent<Animator>().GetBool("FootStomping")) 
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(delaySpawn());

        }

    }

    private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(0.15f);
        Instantiate(obj, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
