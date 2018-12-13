using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Elevator : MonoBehaviour {

    public int nextScene;
    private string[] sceneNames;

    public void Awake() {
        nextScene = SceneManager.GetActiveScene().buildIndex;
        sceneNames = new string[] { "Main", "Level_One", "Elevator_One", "Level_Two", "Elevator_Two", "Level_Three"};
        StartCoroutine(SwitchScenes());
    }

    private IEnumerator SwitchScenes() {
        yield return new WaitForSeconds(11f);
        Initiate.Fade(sceneNames[nextScene], Color.black, 1f);
    }
}
