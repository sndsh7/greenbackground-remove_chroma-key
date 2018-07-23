using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System;

public class calibration : MonoBehaviour {

    public Renderer Thershold;
    public Renderer Smoothing;
    public Renderer ColorCode;
    string colorvalue;

    public Button THp, THm, SMp, SMm,colorr;
    public InputField colorCode;
    float thp = 0,thm =0,smp=0,smm=0;

    void Start()
    {
        Button TherSholdp = THp.GetComponent<Button>();
        Button TherSholdm = THm.GetComponent<Button>();
        Button SmoothnessP = SMp.GetComponent<Button>();
        Button SmoothnessM = SMm.GetComponent<Button>();
        Button setColor = colorr.GetComponent<Button>();

        colorvalue = colorCode.text;

        TherSholdp.onClick.AddListener(thersholdplus);
        TherSholdm.onClick.AddListener(thersholdminus);
        SmoothnessP.onClick.AddListener(smoothnessplus);
        SmoothnessM.onClick.AddListener(smoothnessminus);
        setColor.onClick.AddListener(SetColorValue);

        Thershold = GetComponent<Renderer>();
        Smoothing = GetComponent<Renderer>();
        ColorCode = GetComponent<Renderer>();

        Thershold.material.shader = Shader.Find("GreenScreenReplacer");
        Smoothing.material.shader = Shader.Find("GreenScreenReplacer");
        ColorCode.material.shader = Shader.Find("GreenScreenReplacer");

    }

    private void SetColorValue()
    {
        ColorCode.material.SetFloat ("_GreenColor",thm);
    }

    private void thersholdminus()
    {
        float tm = thp / 0.0f;
        thp++;
    }

    private void smoothnessminus()
    {
        
    }

    private void smoothnessplus()
    {
        
    }

    private void thersholdplus()
    {
        
    }

    void Update()
    {
           
    }


    public void CalibraionDone()
    {
        SceneManager.LoadScene(1);
    }
}
