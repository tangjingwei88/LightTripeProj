using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdapt : MonoBehaviour {

    float orthographicsize = 5f;
    float inital_aspect_Ratio = 1.77f;

    float screenH;
    float screenW;
    float fact_aspect_Rotio;
    private void Start()
    {
        screenH = Screen.height;
        screenW = Screen.width;
        fact_aspect_Rotio = screenW / screenH;
        Camera.main.orthographicSize = (orthographicsize * inital_aspect_Ratio) / fact_aspect_Rotio;
    }

}
