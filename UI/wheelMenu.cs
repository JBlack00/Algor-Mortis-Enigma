using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wheelMenu : MonoBehaviour {
    public GameObject wheel;
    public Button[] wheelButtons;
    public string CurrentItem;
    public PlayerInteractions playerInteractionScript;
	// Use this for initialization
	void Start () {
        playerInteractionScript = GameObject.Find("FPSCamera").GetComponent<PlayerInteractions>();

    }

    // Update is called once per frame
    void Update()
    {
        if (UseNotepad.isNotePadInUse ==false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                checkWheel();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                SetWheel();
            }
        }
    }
    void checkWheel()
    {
        wheel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        vp_Utility.LockCursor = false;
        vp_LocalPlayer.DisableGameplayInput();
        vp_LocalPlayer.DisableFreeLook();
        vp_LocalPlayer.ShowMouseCursor();
        vp_LocalPlayer.InputManager.MouseCursorForced = true;
       
    }
    void SetWheel()
    {
        wheel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        vp_LocalPlayer.EnableGameplayInput();
        vp_LocalPlayer.EnableFreeLook();
        vp_LocalPlayer.HideMouseCursor();
        vp_LocalPlayer.InputManager.MouseCursorForced = false;
        vp_Utility.LockCursor =true;
        
    }
    public void SetTool()
    {
        playerInteractionScript.state = 2;
    }
    public void Onclick(GameObject thisButton)
    {
        for(int i=0; i < wheelButtons.Length; i++)
        {
            wheelButtons[i].GetComponent<Button>().interactable = true;
        }
        thisButton.GetComponent<Button>().interactable = false;
        SetCurrentItem(thisButton.name);
    }
    void SetCurrentItem(string buttonLocation)
    {
        switch (buttonLocation)
        {
            case "ButtonTOP":
                CurrentItem = "Blacklight";
                break;
            case "ButtonBOT":
                CurrentItem = "Camera";
                break;
            case "ButtonLEFT":
                CurrentItem = "Fingerprint";
                break;
            case "ButtonRIGHT":
                CurrentItem = "Swab";
                break;
        }


    }
}
