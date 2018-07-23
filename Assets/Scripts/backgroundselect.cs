using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backgroundselect : MonoBehaviour
{

    public Button image0, image1, image2, image3, image4, image5;
    private bool img0 = false;
    private bool img1 = false;
    private bool img2 = false;
    private bool img3 = false;
    private bool img4 = false;
    private bool img5 = false;

    void Start()
    {
        Button Image0 = image0.GetComponent<Button>();
        Button Image1 = image1.GetComponent<Button>();
        Button Image2 = image2.GetComponent<Button>();
        Button Image3 = image3.GetComponent<Button>();
        Button Image4 = image4.GetComponent<Button>();
        Button Image5 = image5.GetComponent<Button>();


        Image0.onClick.AddListener(TaskOnClick0);
        Image1.onClick.AddListener(TaskOnClick1);
        Image2.onClick.AddListener(TaskOnClick2);
        Image3.onClick.AddListener(TaskOnClick3);
        Image4.onClick.AddListener(TaskOnClick4);
        Image5.onClick.AddListener(TaskOnClick5);

    }


    void TaskOnClick0()
    {
        img0 = true;
        Debug.Log("fistbackselect" + img0);
        if (img0 == true)
        {
            PrivewScript Background0 = new PrivewScript();
            Background0.SetBackground0(img0);
            SceneManager.LoadScene(3);
            img0 = false;
        }
    }
    void TaskOnClick1()
    {

        img1 = true;
        if (img1 == true)
        {
            PrivewScript Background1 = new PrivewScript();
            Background1.SetBackground1(img1);
            SceneManager.LoadScene(3);
            img1 = false;
        }
    }
    void TaskOnClick2()
    {
        img2 = true;
        if (img2 == true)
        {
            PrivewScript Background2 = new PrivewScript();
            Background2.SetBackground2(img2);
            SceneManager.LoadScene(3);
            img2 = false;
        }


    }

    void TaskOnClick3()
    {
        img3 = true;
        Debug.Log("fistbackselect" + img3);
        if (img3 == true)
        {
            PrivewScript Background3 = new PrivewScript();
            Background3.SetBackground3(img3);
            SceneManager.LoadScene(3);
            img3 = false;
        }

    }
    void TaskOnClick4()
    {

        img4 = true;
        if (img4 == true)
        {
            PrivewScript Background4 = new PrivewScript();
            Background4.SetBackground4(img4);
            SceneManager.LoadScene(3);
            img4 = false;
        }

    }
    void TaskOnClick5()
    {
        img5 = true;
        if (img5 == true)
        {
            PrivewScript Background5 = new PrivewScript();
            Background5.SetBackground5(img5);
            SceneManager.LoadScene(3);
            img5 = false;
        }
    }
}
