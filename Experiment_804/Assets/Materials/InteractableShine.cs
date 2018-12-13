using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableShine : MonoBehaviour {

    private Material shine;
    private float val;
    [Range(0, 1)]
    public float shaderWidth = 0.01f;
    public float cooldown = 2f;

    [Range(0.01f, 0.1f)]
    public float shineSpeed = 0.01f;

	// Use this for initialization
	void Start () {
        shine = GetComponent<SpriteRenderer>().material;
        shine.SetFloat("_ShineWidth", shaderWidth);
        StartCoroutine(ShinePeriodically());
	}
	
	private IEnumerator ShinePeriodically() {

        while (true) {
            val = 0f;
            yield return new WaitForSeconds(cooldown);

            while (val < 1f) {
                shine.SetFloat("_ShineLocation", val);
                yield return null;
                val += shineSpeed;
            }
        }
    }
}
