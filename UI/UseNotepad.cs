using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseNotepad : MonoBehaviour {
    public static bool isNotePadInUse;
    public bool UseNotepadNow;
    public InputField IF;
    public Animator ani;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab) && IF.isFocused == false)
        {
           
            if (UseNotepadNow)
            {
                UseNotepadNow = false;
            }
            else
            {
                Debug.Log("working");
                UseNotepadNow = true;
                StopFPS();
                IF.ActivateInputField();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && UseNotepadNow == true)
        {
            StartFPS();
            UseNotepadNow = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && IF.isFocused == true)
        {
            IF.DeactivateInputField();
           
            
        }

      
        ani.SetBool("UseNotepad", UseNotepadNow);
        isNotePadInUse = UseNotepadNow;
    }
    void StopFPS()
    {
        Cursor.lockState = CursorLockMode.None;
        vp_Utility.LockCursor = false;
        vp_LocalPlayer.DisableGameplayInput();
        vp_LocalPlayer.DisableFreeLook();
        vp_LocalPlayer.ShowMouseCursor();
        vp_LocalPlayer.InputManager.MouseCursorForced = true;
       

    }
    void StartFPS()
    {
        
        vp_LocalPlayer.EnableGameplayInput();
        vp_LocalPlayer.EnableFreeLook();
        vp_LocalPlayer.HideMouseCursor();
        vp_LocalPlayer.InputManager.MouseCursorForced = false;
        vp_Utility.LockCursor = true;
    }
}
