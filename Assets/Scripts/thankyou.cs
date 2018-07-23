using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thankyou : MonoBehaviour {

    void Start()
    {
        StartCoroutine("ToMainScreen");
    }

    IEnumerator ToMainScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
