using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBlink : MonoBehaviour {

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
            animator.Play("MainMenuBlink", 0, -1);
            yield return new WaitForSeconds(5f);
        }
    }
}
