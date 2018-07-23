using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour {

    public RawImage rawImage;
    WebCamTexture webcamTexture = null;

    private bool CamAvailable;
    private static bool CameraStatuss = false;

    public void SetPhotoTaken(bool PT)
    {
        CameraStatuss = PT;
    }

    // Use this for initialization
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        //Get the used camera name for the WebCamTexture initialization.
        string camName = devices[0].name;
        webcamTexture = new WebCamTexture(camName);
        Debug.Log("WebCamAvailable :" + camName);
        //Render the image in the screen.
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        Debug.Log("Camera status" + CameraStatuss);

        //if (devices.Length == 0)
        //{
        //    Debug.Log("No Camera Found");
        //    CamAvailable = false;
        //    return;
        //}
        //for (int i = 0; i < devices.Length; i++)
        //{
        //    Debug.Log("Webcam available :" + devices[i].name);
        //}
        //WebCamTexture realtimefeed = new WebCamTexture();
        //rawImage.texture = realtimefeed;
        //rawImage.material.mainTexture = realtimefeed;
        //realtimefeed.Play();
        //CamAvailable = true;

    }

    // Update is called once per frame
    void Update()
    {
       
        //This is to take the picture, save it and stop capturing the camera image.
        //if (Input.GetMouseButtonDown(0))
        if(CameraStatuss == true)
        {

            //yield return new WaitForSeconds(4);
            webcamTexture.Stop();
           
        }
        
        
    }

    void SaveImage()
    {
        //Create a Texture2D with the size of the rendered image on the screen.
        Texture2D texture = new Texture2D(rawImage.texture.width, rawImage.texture.height, TextureFormat.ARGB32, false);

        //Save the image to the Texture2D
        texture.SetPixels(webcamTexture.GetPixels());
        texture.Apply();

        //Encode it as a PNG.
        byte[] bytes = texture.EncodeToPNG();

        //Save it in a file.
        //File.WriteAllBytes(Application.dataPath + ".png", bytes);
        //Debug.Log(Application.dataPath);
    }

}
