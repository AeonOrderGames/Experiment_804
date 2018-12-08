using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

    private Queue<GameObject> boxes;
    public GameObject hand;
    public GameObject box1;
    public GameObject box2;
    public ShelfAvailability shelfStatus;

    // Use this for initialization
    void Start () {
        boxes = new Queue<GameObject>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (hand.GetComponent<PlayerHandMovement>().Pushing)
        {
            Debug.Log("hand is pushing");
            if (shelfStatus.available)
            {
                Debug.Log("There is nothing on the shelf");
                if (boxes.Count == 0)
                {
                    Debug.Log("Box should fall down");
                    boxes.Enqueue(box1);
                    box1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
                else if (boxes.Count == 1)
                {
                    boxes.Enqueue(box2);
                    box2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
                else
                {
                    var tempBox = boxes.Dequeue();
                    tempBox.transform.position = new Vector3(0.842f, 2.5f, 0);
                    boxes.Enqueue(tempBox);
                }
            }

        }

    }

}
