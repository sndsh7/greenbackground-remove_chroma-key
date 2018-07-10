using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour {

    public RawImage rawImage;
	// Use this for initialization
	void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length;i++){
            Debug.Log("Webcam available :" + devices[i].name);
        }
        WebCamTexture realtimefeed  = new WebCamTexture();
        rawImage.texture = realtimefeed;
        rawImage.material.mainTexture = realtimefeed;
        realtimefeed.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
