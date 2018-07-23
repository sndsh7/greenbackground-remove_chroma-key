using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class welcome_button : MonoBehaviour {

	public void welcomeBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void calibrationGreenScreen()
    {
        SceneManager.LoadScene(6);
    }
}
