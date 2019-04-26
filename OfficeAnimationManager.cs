using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OfficeAnimationManager : MonoBehaviour
{
    public Animator OfficeDoorPivot;
    public Animator Camera;
    private GameObject travelToCrimeSceneText;
    private GameObject interactUI;
    private bool turnToDoor;
    private bool turnRightToDesk;
    private bool turnToBoard;
    private bool turnLeftToDesk;
    private bool isIdle;
    private bool open;
    private bool goToCrimeScene;

    public SceneController SCscript;
    // Use this for initialization
    void Start ()
    {
		Cursor.visible = true;
		Screen.lockCursor = false;
        interactUI = GameObject.FindGameObjectWithTag("InteractUI");
        travelToCrimeSceneText = GameObject.FindGameObjectWithTag("LeaveSceneUI");
        isIdle = true;
        goToCrimeScene = false;
        interactUI.SetActive(false);
        travelToCrimeSceneText.SetActive(false);
        SCscript = GameObject.Find("MurderManager").GetComponent<SceneController>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        CameraAnimations();
        LeaveOffice();
		if (Input.GetKey ("escape")) {
			GameObject.Find ("PlayerUI").transform.GetChild (3).gameObject.SetActive (false);
		}
    }

    public void CameraAnimations()
    {   
        if (Input.GetKeyDown("a") && isIdle == true)
        {
			LookAtDoor(true);
        }
        if (Input.GetKeyDown("d") && isIdle == true)
        {
            turnToBoard = true;
            isIdle = false;
            OfficeDoorPivot.SetBool("IsIdle", false);
            Camera.SetBool("TurnToDoor", false);
            Camera.SetBool("TurnRightToDesk", false);
            Camera.SetBool("IsIdle", false);
            Camera.SetBool("TurnToBoard", true);
            Camera.SetBool("TurnLeftToDesk", false);
        }
        if (Input.GetKeyDown("d") && turnToDoor == true)
        {
            interactUI.SetActive(false);
            travelToCrimeSceneText.SetActive(false);
            CloseDoor();
            isIdle = true;
            turnToBoard = false;
            turnToDoor = false;
            Camera.SetBool("TurnToDoor", false);
            Camera.SetBool("TurnRightToDesk", true);
            Camera.SetBool("IsIdle", false);
            Camera.SetBool("TurnToBoard", false);
            Camera.SetBool("TurnLeftToDesk", false);
        }
        if (Input.GetKeyDown("a") && turnToBoard == true)
        {
            isIdle = true;
            turnToBoard = false;
            OfficeDoorPivot.SetBool("IsIdle", true);
            Camera.SetBool("TurnToDoor", false);
            Camera.SetBool("TurnRightToDesk", false);
            Camera.SetBool("IsIdle", false);
            Camera.SetBool("TurnToBoard", false);
            Camera.SetBool("TurnLeftToDesk", true);
        }
    }

	public void OpenDoor(bool useUI)
    {
        open = true;

        if(open == true)
        {
            OfficeDoorPivot.SetBool("CloseDoor", false);
            OfficeDoorPivot.SetBool("IsIdle", false);
            OfficeDoorPivot.SetBool("OpenDoor", true);
			interactUI.SetActive(useUI);
			travelToCrimeSceneText.SetActive(useUI);
            goToCrimeScene = true;     
        }
    }

    public void CloseDoor()
    {
        open = false;

        if (open == false)
        {
            OfficeDoorPivot.SetBool("OpenDoor", false);
            OfficeDoorPivot.SetBool("IsIdle", false);
            OfficeDoorPivot.SetBool("CloseDoor", true);
        }
    }
	public void LookAtDoor(bool useUi){
		OpenDoor(useUi);
		turnToDoor = true;
		isIdle = false;
		Camera.SetBool("TurnRightToDesk", false);
		Camera.SetBool("IsIdle", false);
		Camera.SetBool("TurnToBoard", false);
		Camera.SetBool("TurnLeftToDesk", false);
		Camera.SetBool("TurnToDoor", turnToDoor);
	}
	public void GetStatement(GameObject obj){
		GameObject.Find ("InteractionManager").GetComponent<InteractionManager> ().SetTypeOfInteraction ("FakeLeaveRoom",obj);
	}
	public void SendToCourt(GameObject obj){
		GameObject.Find ("InteractionManager").GetComponent<InteractionManager> ().SetTypeOfInteraction ("FakeLeaveRoom",obj);
	}
    public void LeaveOffice()
    {
        if (Input.GetKeyDown("e") && goToCrimeScene == true)
        {
            if (SCscript.thisScene == "TUT")
            {
                SceneManager.LoadScene("CrimeScene1");
            }
            if (SCscript.thisScene == "NYapp")
            {
                SceneManager.LoadScene("CrimeScene2");
            }
            if (SCscript.thisScene == "BigApp")
            {
                SceneManager.LoadScene("CrimeScene3");
            }
        }
    }
	public void ShowCluePicture(GameObject obj){
		GameObject.Find ("PlayerUI").transform.GetChild (3).gameObject.SetActive (true);
		GameObject.Find ("PlayerUI").transform.GetChild (3).GetComponent<Image> ().sprite = obj.GetComponent<Image> ().sprite;
	}
}

