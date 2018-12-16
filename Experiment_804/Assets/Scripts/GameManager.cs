using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool inRoom;
    public bool roomVisited;

    private GameObject arm;
    private GameObject leg;

    public Vector3 armPos = new Vector3(9.35f, -1f, 0f);
    public Vector3 legPos = new Vector3(8.35f, -0.61f, 0);

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level) {

        arm = FindObjectOfType<PlayerArmMovement>().gameObject;
        leg = FindObjectOfType<LegMovement>().gameObject;

        if (level == 8) {
            roomVisited = true;
        } 


        if(roomVisited && level == 6) {
            arm.transform.position = armPos;
            leg.transform.position = legPos;
        }

    }
}
