using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEyeLevelThree : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(BlinkDelay());
    }

    private IEnumerator BlinkDelay()
    {
        while (true)
        {
            animator.Play("BlinkEyeLevel3", 0, -1);
            yield return new WaitForSeconds(6f);
        }
    }
}
