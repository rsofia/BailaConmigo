using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamToTexture : MonoBehaviour
{
    public RawImage rawDisplay;
    //public RenderTexture renderTexture;
    public Camera cam;

    private void Start()
    {
        DisplayViewOnCamera();
    }

    public void DisplayViewOnCamera()
    {
        //cam.targetTexture = renderTexture;
        rawDisplay.texture = cam.targetTexture;
    }
}
