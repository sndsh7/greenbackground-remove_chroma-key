﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitBtn : MonoBehaviour {

    public void backBtn()
    {
        SceneManager.LoadScene(1);
    }
}
