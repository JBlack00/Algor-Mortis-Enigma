using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLayers : MonoBehaviour
{
    public Text SettingsText;
    public Text CreditsText;
    public Text MusicVolumeText;
    public Text DarylText;
    public Text JulieText;
    public Text CallumText;
    public Image DarylImage;
    public Image JulieImage;
    public Image CallumImage;
    public GameObject AudioSlider;
    public GameObject PlayButton;
    public GameObject SettingButton;
    public GameObject CreditsButton;
    public GameObject ExitGameButton;
    public GameObject BackButton;
    public bool mainMenuLayer;
    public bool settingsLayer;
    public bool creditsLayer;
    public bool backButton;

    // Use this for initialization
    void Start ()
    {
        backButton = GameObject.FindGameObjectWithTag("BackButton");
        mainMenuLayer = true;
        settingsLayer = false;
        creditsLayer = false;
        backButton = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Layers();
	}

    //Different Menu Screens
    public void Layers()
    {   //Main Menu
        if(mainMenuLayer == true)
        {
            CreditsText.enabled = false;
            SettingsText.enabled = false;
            MusicVolumeText.enabled = false;
            AudioSlider.SetActive(false);
            PlayButton.SetActive(true);
            SettingButton.SetActive(true);
            CreditsButton.SetActive(true);
            ExitGameButton.SetActive(true);
            BackButton.SetActive(false);
            DarylText.enabled = false;
            JulieText.enabled = false;
            CallumText.enabled = false;
            DarylImage.enabled = false;
            JulieImage.enabled = false;
            CallumImage.enabled = false;
        }
        //Settings Menu
        if (settingsLayer == true)
        {
            CreditsText.enabled = false;
            SettingsText.enabled = true;
            MusicVolumeText.enabled = true;
            AudioSlider.SetActive(true);
            PlayButton.SetActive(false);
            SettingButton.SetActive(false);
            CreditsButton.SetActive(false);
            ExitGameButton.SetActive(false);
            BackButton.SetActive(true);
            DarylText.enabled = false;
            JulieText.enabled = false;
            CallumText.enabled = false;
            DarylImage.enabled = false;
            JulieImage.enabled = false;
            CallumImage.enabled = false;
        }
        //Credits Menu
        if (creditsLayer == true)
        {
            DarylText.enabled = true;
            JulieText.enabled = true;
            CallumText.enabled = true;
            DarylImage.enabled = true;
            JulieImage.enabled = true;
            CallumImage.enabled = true;
            SettingsText.enabled = false;
            CreditsText.enabled = true;
            MusicVolumeText.enabled = false;
            AudioSlider.SetActive(false);
            PlayButton.SetActive(false);
            SettingButton.SetActive(false);
            CreditsButton.SetActive(false);
            ExitGameButton.SetActive(false);
            BackButton.SetActive(true);
        }
    }
}
