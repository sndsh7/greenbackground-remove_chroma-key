using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class TokenPanel : MonoBehaviour {
    [SerializeField]
    Text getInput;
    static string token;
    string InputString;

    void Start()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Initial");
        foreach(FileInfo file in directoryInfo.GetFiles())
        {
            file.Delete();
        }
    }

    public string GetToken()
    {
        return token;
    }

    public void buttonClick()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonListner = EventSystem.current.currentSelectedGameObject.name;
        InputString += buttonListner;

        getInput.text = InputString.ToString();
        token = InputString.ToString();
    }
    public void clearBtn()
    {
        InputString = string.Empty;
        getInput.text = string.Empty;
        Debug.Log("clear");
        
    }
    public void enterBtn()
    {
        SceneManager.LoadScene(2);
        
    }

}
