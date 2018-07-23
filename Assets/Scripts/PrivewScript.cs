using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PrivewScript : MonoBehaviour {

    [SerializeField]
    GameObject PreviewPanel;
    string[] files = null;
    int whichScreenShotIsShown = 0;

    private static bool BImag0 ;
    private static bool BImag1 ;
    private static bool BImag2 ;
    private static bool BImag3;
    private static bool BImag4;
    private static bool BImag5;

    public void SetBackground0(bool bgimg0)
    {
        BImag0 = bgimg0;
    }
    public void SetBackground1(bool bgimg1)
    {
        BImag1 = bgimg1;
    }
    public void SetBackground2(bool bgimg2)
    {
        BImag2 = bgimg2;
    }
    public void SetBackground3(bool bgimg3)
    {
        BImag3 = bgimg3;
    }
    public void SetBackground4(bool bgimg4)
    {
        BImag4 = bgimg4;
    }
    public void SetBackground5(bool bgimg5)
    {
        BImag5 = bgimg5;
    }

    // Use this for initialization
    void Start()
    {
        
        if (BImag0 == true)
        {
            files = Directory.GetFiles(Application.dataPath+"/Background/","0.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag0 = false;
            }
        }
        if (BImag1 == true)
        {
            files = Directory.GetFiles(Application.dataPath + "/Background/", "1.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag1 = false;
            }
        }
        if (BImag2 == true)
        {
            files = Directory.GetFiles(Application.dataPath + "/Background/", "2.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag2 = false;
            }
        }
        if (BImag3 == true)
        {
            files = Directory.GetFiles(Application.dataPath + "/Background/", "3.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag3 = false;
            }
        }
        if (BImag4 == true)
        {
            files = Directory.GetFiles(Application.dataPath + "/Background/", "4.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag4 = false;
            }
        }
        if (BImag5 == true)
        {
            files = Directory.GetFiles(Application.dataPath + "/Background/", "5.png");
            if (files.Length > 0)
            {
                GetPictureAndShowIt();
                BImag5 = false;
            }
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
