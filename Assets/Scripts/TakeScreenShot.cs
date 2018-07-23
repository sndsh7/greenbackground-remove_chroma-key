// TODO:
// By default, screenshot files are placed next to the executable bundle -- we don't want this in a
// shipping game, as it will fail if the user doesn't have write access to the Applications folder.
// Instead we should place the screenshots on the user's desktop. However, the ~/ notation doesn't
// work, and Unity doesn't have a mechanism to return special paths. Therefore, the correct way to
// solve this is probably with a plug-in to return OS specific special paths.

// Mono/.NET has functions to get special paths... see discussion page. --Aarku

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeScreenShot : MonoBehaviour
{
    private string Initial;
    private static bool PhotoTaken = false;

    public RawImage rawImage;
    WebCamTexture webcamTexture = null;

    public int timeLeft = 4;
    public Text countdownText;

    //private int count = 0;
    string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy:hh:MM:ss");

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        //Get the used camera name for the WebCamTexture initialization.
        string camName = devices[0].name;
        webcamTexture = new WebCamTexture(camName);
        Debug.Log("WebCamAvailable :" + camName);
        //Render the image in the screen.
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        

        GameObject.Find("TimerCanvas").GetComponent<Canvas>().enabled = false;
        //path for Initial folder
        Initial = Application.dataPath + "/Initial";
        //Create folder
        if (Directory.Exists(Initial) == false)
        {
            Directory.CreateDirectory(Initial);
            Debug.Log("Folder Created" + Initial);
        }
    }

    public void Timerr()
    {
        StartCoroutine("LoseTime");
    }
    void Update()
    {
        countdownText.text = ("" + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Smile";
            GameObject.Find("TimerCanvas").GetComponent<Canvas>().enabled = false;
            TakeAShot();
           

        }
        
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject.Find("TimerCanvas").GetComponent<Canvas>().enabled = true;
            timeLeft--;
        }
    }

    public void TakeAShot()
    {
        StartCoroutine("ScreenshotEncode");
       
    }
    public void BackkBtn()
    {
        backkFromMain();
    }

    IEnumerator ScreenshotEncode()
    {
        yield return null;
        //GameObject.Find("TimerCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MyCanvas").GetComponent<Canvas>().enabled = false;
        // wait for graphics to render
        yield return new WaitForEndOfFrame();

        // create a texture to pass to encoding
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // put buffer into texture
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
        yield return 0;

        byte[] bytes = texture.EncodeToPNG();
        // save our test image (could also upload to WWW)
        TokenPanel Token = new TokenPanel();
        string token = Token.GetToken();
        Debug.Log("Token"+token);
        //Absulute Path
        //File.WriteAllBytes(Application.dataPath +"/../Assets/Initial/"+ token + ".png", bytes);
        //Relative Path
        File.WriteAllBytes(Application.dataPath + "/Initial/" +"Initial.png", bytes);

        // Added by Karl. - Tell unity to delete the texture, by default it seems to keep hold of it and memory crashes will occur after too many screenshots.
        DestroyObject(texture);
        GameObject.Find("MyCanvas").GetComponent<Canvas>().enabled = true;
        //Debug.Log( Application.dataPath + "/../testscreen-" + count + ".png" );
        StoppCam();
    }
    private void StoppCam()
    {
        webcamTexture.Stop();
        SceneManager.LoadScene(4);
    }
    private void backkFromMain()
    {
        webcamTexture.Stop();
        SceneManager.LoadScene(2);
    }
}