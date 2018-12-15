using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public float smoothing = 0.5f;

    public GameObject Hand;
    public GameObject Arm;
    public GameObject Foot;
    public GameObject Leg;


    public float minPos = 0;
    public float maxPos = 10;

    private float followPositionX;
    private float followPositionY;
    private Vector3 followPosition;
    private Vector3 newPosition;
    private NextLevel armDestroyed;
    private NextLevel LegDestroyed;

    private void Awake() {
        followPositionX = (Hand.transform.position.x + Foot.transform.position.x) * 0.5f;
        followPositionY = transform.position.y;

        followPosition = new Vector3(followPositionX, followPositionY, transform.position.z);
    }

    private void Start() {
        if (Hand != null) {
            transform.position = new Vector3(Hand.transform.position.x, transform.position.y, transform.position.z);
        }
        else {
            transform.position = new Vector3(Arm.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void LateUpdate() {
        if (Hand != null) {
            if (Hand.activeSelf == false) {
                Hand = Arm;
            }
        }
        if(Foot != null) {
            if (Foot.activeSelf == false) {
                 if (Leg != null) {
                    Foot = Leg;
                 }
            }
        }
        //Edge cases:
        //If the hand is in the elevator
        if (Hand == null && Foot != null) {
            followPosition.x = Foot.transform.position.x;
        }
        //If the leg is in the elevator
        if (Hand != null && Foot == null ) {
            followPosition.x = Hand.transform.position.x;
        }
        //If both hand and foot are still in the scene
        else if (Hand != null && Foot != null) {
            followPosition.x = (Hand.transform.position.x + Foot.transform.position.x) * 0.5f;
        }
     
        if (followPosition.x < minPos) followPosition.x = minPos;

        if (followPosition.x > maxPos) followPosition.x = maxPos;

        newPosition = Vector3.Lerp(transform.position, followPosition, smoothing);
        newPosition.z = -10f;
        transform.position = newPosition;
    }
}
