using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLightFlicker : MonoBehaviour {
    private Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            animator.Play("ElevatorFlickerLights", 0, -1);
            yield return new WaitForSeconds(3f);
        }
    }
}
