using System.Collections;
using System.Collections.Generic;
using System.IO;
using LCPrinter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Printer : MonoBehaviour {
    private static bool PrintIsDone = false;
    public string printerName = "";
    //public string Pathh = Application.dataPath + "\\Initial\\";
    public int copies = 1;
    // Use this for initialization
    public void PrintServices()
    {
        //System.Diagnostics.Process.Start("mspaint.exe", "/pt d:\\screenshots\\sample.jpg");
        //System.Diagnostics.Process.Start("mspaint.exe", "/pt D:\\sandesh_projects\\greenbackground-remove_chroma-key-master\\greenbackground-remove_chroma-key-master\\greenbackground-remove_chroma-key-master_Data\\Initial\\*.png");
        //System.Diagnostics.Process.Start("mspaint.exe","/pt "+ Application.dataPath + "\\Initial\\*.png");
        Print.PrintTextureByPath("C:\\AR_booth\\AR_booth_Data\\Initial\\Initial.png", copies,printerName);
        Debug.Log("C:\\SandeshProjects\\greenbackground - remove_chroma - key - master\\greenbackground - remove_chroma - key - master\\greenbackground - remove_chroma - key - master\\Assets\\Initial\\*.png");
        PrintIsDone = true;
        string time = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        DirectoryInfo sourceInfo = new DirectoryInfo(Application.dataPath + "/Initial");
        DirectoryInfo destInfo = new DirectoryInfo(Application.dataPath + "/Success");
        if (!Directory.Exists(destInfo.FullName))
        {
            Directory.CreateDirectory(destInfo.FullName);
        }
        foreach(FileInfo fi in sourceInfo.GetFiles())
        {
            if(fi.Length != 0)
            {
                fi.CopyTo(Path.Combine(destInfo.ToString(), time + ".png"), true);
                SceneManager.LoadScene(5);
            }
        }
    }
}
