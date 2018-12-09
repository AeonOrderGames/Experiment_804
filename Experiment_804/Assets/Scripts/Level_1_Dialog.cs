using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level_1_Dialog {

    public string name;
    //Min: 3, Max: 10
    [TextArea(3, 50)]
    public string[] sentences;
}
