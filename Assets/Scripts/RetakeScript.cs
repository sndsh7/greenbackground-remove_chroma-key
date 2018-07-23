using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetakeScript : MonoBehaviour {

    private bool DeletePhoto = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Retake();
        }
    }
    public void Retake()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Initial");
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            file.Delete();
            Debug.Log("Initial folder files Deleted");
            DeletePhoto = true;
            if(DeletePhoto == true)
            {
                SceneManager.LoadScene(2);
            }
        }

    }
}
