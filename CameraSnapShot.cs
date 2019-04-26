using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class CameraSnapShot : MonoBehaviour {

    WebCamTexture webCamTexture;

    public GameObject CameraReady;

    public string ScreenCaPDir ;

    public string Name;

    private int count;
    private int ScreenCaps;

    private RawImage RawImage;

    void Start()
    {
     
        ScreenCaPDir = Application.dataPath + "/Resources/CustomPictures/";
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
        ScreenCaps = 0;
        DeletePictures(ScreenCaPDir, Name);
    }

   public  void TakePhoto()
    {
        CameraReady = GameObject.Find("CameraReady");
        ScreenCaps = (FindScreenCaptures(ScreenCaPDir, Name));
        CameraReady.SetActive(false);
        ScreenCapture.CaptureScreenshot(ScreenCaPDir + Name + (ScreenCaps + 1)+ ".png");

        


        CameraReady.SetActive(true);
    }

    int FindScreenCaptures(string DirectoryPath, string FileName)
    {
        //Set count to 0 at every run so we count up from 0 to 
        //how many files exist with the FileName entered
        count = 0;

        //This loops through the files in your entered Directory
        for (int i = 0; i < Directory.GetFiles(DirectoryPath).Length; i++)
        {
            //If any file has the same name as your picture
            if (Directory.GetFiles(DirectoryPath)[i].Contains(FileName))
            {
                //Add 1 to the count because we need to know how many
                //files with the same name exist
                count += 1;
            }
        }
        //Once we know we return that amount
        return count;
    }
    void DeleteThePictures(string DirectoryPath, string FileName)
    {
        for (int i = 0; i < Directory.GetFiles(DirectoryPath).Length; i++)
        {
            //If any file has the same name as your picture
            if (Directory.GetFiles(DirectoryPath)[i].Contains(FileName) && Directory.GetFiles(DirectoryPath)[i].Contains(".png"))
            {
                //Add 1 to the count because we need to know how many
                //files with the same name exist
                Debug.Log(DirectoryPath+ FileName + i + ".png");
                File.Delete(DirectoryPath + FileName + (i +1) +".png");
                File.Delete(DirectoryPath + FileName + (i+1)+ ".png" + ".meta");
                UnityEditor.AssetDatabase.Refresh();

            }
        }
    }
    void DeletePictures(string DirectoryPath, string FileName)
    {
    
      var allFiles = Directory.GetFiles(DirectoryPath);

      for (int i = 0; i < allFiles.Length; i++)
      {
            Debug.Log(allFiles + FileName + i + ".png");
            File.Delete(allFiles[i]);       
       }
        UnityEditor.AssetDatabase.Refresh();
    }
}
