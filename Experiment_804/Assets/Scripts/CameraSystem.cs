using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public float smoothing = 0.5f;

    public GameObject Hand;
    public GameObject Foot;

    public float followPositionX;
    public float followPositionY;

    private Vector3 followPosition;

    private void Awake() {
        followPositionX = (Hand.transform.position.x - Foot.transform.position.x) * 0.5f;
        followPositionY = transform.position.y;

        followPosition = new Vector3(followPositionX, followPositionY, transform.position.z);
    }

    private void LateUpdate() {
        followPosition.x = (Hand.transform.position.x + Foot.transform.position.x) * 0.5f;

        Vector3 newPosition = Vector3.Lerp(transform.position, followPosition, smoothing);
        transform.position = newPosition;
    }
}
