using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PreviewTakeShot : MonoBehaviour {

    [SerializeField]
    GameObject PreviewPanel;
    string[] files = null;
    int whichScreenShotIsShown = 0;

    // Use this for initialization
    void Start()
    {      
        files = Directory.GetFiles(Application.dataPath + "/Initial/","*.png");
        if (files.Length > 0)
        {
            GetPictureAndShowIt();
        }

    }

    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        PreviewPanel.GetComponent<Image>().sprite = sp;
    }

    Texture2D GetScreenshotImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }
}
