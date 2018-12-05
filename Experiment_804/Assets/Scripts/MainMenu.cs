using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame () {
        Initiate.Fade("Main", Color.black, 2f);
    }

    public void QuitGame() {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
