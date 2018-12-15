using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoorSwap : MonoBehaviour {

    public GameObject doorsClose;
    public GameObject doorsOpen;

    private void Start() {
        StartCoroutine(SwapDoors());
    }

    private IEnumerator SwapDoors() {
        yield return new WaitForSeconds(2f);
        doorsClose.SetActive(false);
        doorsOpen.SetActive(true);

    }
}
