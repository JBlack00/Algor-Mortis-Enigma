using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public MenuLayers layersScript;
    public bool playButton;
    public bool settingsButton;
    public bool creditsButton;
    public bool backButton;
    public bool exitButton;

    public void OnMouseDown()
    {
        if(playButton == true)
        {
            SceneManager.LoadScene("DetectiveOffice");
        }
        if (settingsButton == true)
        {
            layersScript.settingsLayer = true;
            layersScript.mainMenuLayer = false;
            layersScript.creditsLayer = false;
        }
        if (creditsButton == true)
        {
            layersScript.mainMenuLayer = false;
            layersScript.settingsLayer = false;
            layersScript.creditsLayer = true;
        }
        if (backButton == true)
        {
            layersScript.mainMenuLayer = true;
            layersScript.settingsLayer = false;
            layersScript.creditsLayer = false;
        }
        if (exitButton == true)
        {   //**Test this in the build as can't test it in the editor**
            Application.Quit();//Closes game
            Debug.Log("Quit Game");
        }
    }
}
