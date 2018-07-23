using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Handler : MonoBehaviour {
    public static int SceneNumber;
    // Use this for initialization
    public void SetSceneIndex(int SceneIndex)
    {
        SceneNumber = SceneIndex;
    }
    private void Start()
    {
        if (SceneNumber == 0)
            StartCoroutine("ToEntryToken");
    }

    IEnumerator ToEntryToken()
    {
        yield return new WaitForSeconds(3);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
        Debug.Log("Scene 1");
    }

}
