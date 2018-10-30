using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public Vector3 firstDir;

    private static GameData instance = new GameData();
    public static GameData Instance {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }
}
