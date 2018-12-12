using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfAvailability : MonoBehaviour {
    public bool available;
    // Use this for initialization
    void Start () {
        available = true;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "MetalBox1" || col.gameObject.name == "MetalBox2")
        {
            available = false;
        }
    }

    private void OnEnable()
    {
        available = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "MetalBox1" || col.gameObject.name == "MetalBox2")
        {
            available = true;
        }
    }
}
