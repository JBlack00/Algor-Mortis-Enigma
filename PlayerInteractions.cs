using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInteractions : MonoBehaviour
{
    private float interactDistance = 3f;
    public Animator anim;
	public int state =0;


	public GameObject LookAtUI;
    public GameObject interactUI;
    private GameObject leaveCrimeSceneText;
    private GameObject microwaveDoor;
    private GameObject[] cupboardDoors;
    private GameObject[] kitchenDrawers;
    private GameObject[] freezer;
    private GameObject[] binLid;
    private GameObject[] cookerDoor;
    private GameObject[] bedsideTableDrawers;
    private GameObject[] dressingTableDrawers;
    private GameObject[] deskDrawers;
    private GameObject[] roomDoor;

    private bool roomDoor1IsIdle;
    private bool roomDoor1IsOpen;
    private bool roomDoor1IsClosed;
    private bool roomDoor2IsOpen;
    private bool roomDoor2IsClosed;

    //---Kitchen_Start--//
    private bool cupboardDoorIsIdle;
    private bool cupboardDoorIsOpen;
    private bool cupboardDoorIsClosed;
    private bool kitchenDrawerIsIdle;
    private bool kitchenDrawerIsOpen;
    private bool kitchenDrawerIsClosed;
    private bool freezerDoorIsIdle;
    private bool freezerDoorIsOpen;
    private bool freezerDoorIsClosed;
    private bool binLidIsIdle;
    private bool binLidIsOpen;
    private bool binLidIsClosed;
    private bool microwaveDoorIsIdle;
    private bool microwaveDoorIsOpen;
    private bool microwaveDoorIsClosed;
    private bool cookerDoorIsIdle;
    private bool cookerDoorIsOpen;
    private bool cookerDoorIsClosed;
    //---Kitchen_End--//

    //---Bedroom_Start--//
    private bool bedsideTableDrawerIsIdle;
    private bool bedsideTableDrawerIsOpen;
    private bool bedsideTableDrawerIsClosed;
    private bool dressingTableDrawerIsIdle;
    private bool dressingTableDrawerIsOpen;
    private bool dressingTableDrawerIsClosed;
    private bool deskDrawerIsIdle;
    private bool deskDrawerIsOpen;
    private bool deskDrawerIsClosed;
    //---Bedroom_End--//


	public InteractionManager InteractScipt;


    // Use this for initialization
    void Start()
    {
		InteractScipt = GameObject.Find ("InteractionManager").GetComponent<InteractionManager> ();
        cupboardDoors = GameObject.FindGameObjectsWithTag("CupboardDoor");
        kitchenDrawers = GameObject.FindGameObjectsWithTag("KitchenDrawer");
        freezer = GameObject.FindGameObjectsWithTag("Freezer");
        binLid = GameObject.FindGameObjectsWithTag("BinLid");
        microwaveDoor = GameObject.FindGameObjectWithTag("MicrowaveDoor");
        cookerDoor = GameObject.FindGameObjectsWithTag("CookerDoor");
        bedsideTableDrawers = GameObject.FindGameObjectsWithTag("BedsideDrawer");
        dressingTableDrawers = GameObject.FindGameObjectsWithTag("DresserDrawer");
        deskDrawers = GameObject.FindGameObjectsWithTag("DeskDrawer");
        roomDoor = GameObject.FindGameObjectsWithTag("RoomDoor");
        interactUI = GameObject.FindGameObjectWithTag("InteractUI");
		LookAtUI = GameObject.FindGameObjectWithTag("LookAtUI");
        leaveCrimeSceneText = GameObject.FindGameObjectWithTag("LeaveSceneUI");

		LookAtUI.SetActive(false);
        interactUI.SetActive(false);
        leaveCrimeSceneText.SetActive(false);

        cupboardDoorIsIdle = true;
        cupboardDoorIsOpen = false;
        cupboardDoorIsClosed = false;

        kitchenDrawerIsIdle = true;
        kitchenDrawerIsOpen = false;
        kitchenDrawerIsClosed = false;

        bedsideTableDrawerIsIdle = true;
        bedsideTableDrawerIsOpen = false;
        bedsideTableDrawerIsClosed = false;

        dressingTableDrawerIsIdle = true;
        dressingTableDrawerIsOpen = false;
        dressingTableDrawerIsClosed = false;

        deskDrawerIsIdle = true;
        deskDrawerIsOpen = false;
        deskDrawerIsClosed = false;

        freezerDoorIsIdle = true;
        freezerDoorIsOpen = false;
        freezerDoorIsClosed = false;

        binLidIsIdle = true;
        binLidIsOpen = false;
        binLidIsClosed = false;

        microwaveDoorIsIdle = true;
        microwaveDoorIsOpen = false;
        microwaveDoorIsClosed = false;

        cookerDoorIsIdle = true;
        cookerDoorIsOpen = false;
        cookerDoorIsClosed = false;

        roomDoor1IsIdle = true;
        roomDoor1IsOpen = false;
        roomDoor1IsClosed = false;
        roomDoor2IsOpen = false;
        roomDoor2IsClosed = false;
    }

    // Update is called once per frame
    void Update()
    {// control player normally
		InteractUI();
		switch (state) {
		case 0:
			PlayerInteraction ();

			break;
		case 1:
			LookingAtClue ();
			break;
		}

       
    }
	public void LookingAtClue(){
		GameObject ThisClue=InteractScipt.LookatClueScript.GetCurrentClue();
		if (Input.GetKey ("a")) {
			ThisClue.transform.Rotate(Vector3.left ,Time.deltaTime*150f);
			Debug.Log("a pressed");
		}
		if (Input.GetKey ("d")) {
			ThisClue.transform.Rotate(Vector3.right,Time.deltaTime*150f);
			Debug.Log("d pressed");
		}
		if (Input.GetKey ("w")) {
			ThisClue.transform.Rotate(Vector3.up,Time.deltaTime*150f);
			Debug.Log("w pressed");
		}
		if (Input.GetKey ("s")) {
			ThisClue.transform.Rotate(Vector3.down,Time.deltaTime*150f);
			Debug.Log("s pressed");
		}
		if (Input.GetKey (KeyCode.Backspace)) {
			InteractScipt.LookatClueScript.StopLooking();
			InteractScipt.SetTypeOfInteraction("RemoveLookAtClue",null);
			Debug.Log("Escape pressed");
		}
		if (Input.GetKeyDown("f")) {
			Debug.Log("f pressed");
			InteractScipt.SetTypeOfInteraction("AddToInvo",InteractScipt.LookatClueScript.CurrentObject);
			

		}
		//if (Input.GetKeyDown ("esc")) {
		//	InteractScipt.LookatClueScript.StopLooking();
		//}

	}
		public void PlayerInteraction()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.blue);

        if (Input.GetKeyDown("e"))
        {
            Ray ray = new Ray(transform.position, transform.forward);//Shoots raycast forward
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                anim = hit.transform.gameObject.GetComponent<Animator>();

                //Room Door Interactions
                if (hit.collider.tag == "RoomDoor" && roomDoor1IsIdle == true)
                {
                    roomDoor1IsIdle = false;
                    roomDoor1IsOpen = true;
                    roomDoor1IsClosed = false;
                    roomDoor2IsOpen = false;
                    roomDoor2IsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor1", true);
                    anim.SetBool("CloseDoor1", false);
                    anim.SetBool("OpenDoor2", false);
                    anim.SetBool("CloseDoor2", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "RoomDoor" && roomDoor1IsOpen == true)
                {
                    roomDoor1IsIdle = false;
                    roomDoor1IsOpen = false;
                    roomDoor1IsClosed = true;
                    roomDoor2IsOpen = false;
                    roomDoor2IsClosed = false;
                    anim.SetBool("DoorIdle1", false);
                    anim.SetBool("OpenDoor1", false);
                    anim.SetBool("CloseDoor1", true);
                    anim.SetBool("OpenDoor2", false);
                    anim.SetBool("CloseDoor2", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "RoomDoor" && roomDoor1IsClosed == true)
                {
                    roomDoor1IsIdle = false;
                    roomDoor1IsOpen = false;
                    roomDoor1IsClosed = false;
                    roomDoor2IsOpen = true;
                    roomDoor2IsClosed = false;
                    anim.SetBool("DoorIdle1", false);
                    anim.SetBool("OpenDoor1", false);
                    anim.SetBool("CloseDoor1", false);
                    anim.SetBool("OpenDoor2", true);
                    anim.SetBool("CloseDoor2", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "RoomDoor" && roomDoor2IsOpen == true)
                {
                    roomDoor1IsIdle = false;
                    roomDoor1IsOpen = false;
                    roomDoor1IsClosed = false;
                    roomDoor2IsOpen = false;
                    roomDoor2IsClosed = true;
                    anim.SetBool("DoorIdle1", false);
                    anim.SetBool("OpenDoor1", false);
                    anim.SetBool("CloseDoor1", false);
                    anim.SetBool("OpenDoor2", false);
                    anim.SetBool("CloseDoor2", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "RoomDoor" && roomDoor2IsClosed == true)
                {
                    roomDoor1IsIdle = false;
                    roomDoor1IsOpen = true;
                    roomDoor1IsClosed = false;
                    roomDoor2IsOpen = false;
                    roomDoor2IsClosed = false;
                    anim.SetBool("DoorIdle1", false);
                    anim.SetBool("OpenDoor1", true);
                    anim.SetBool("CloseDoor1", false);
                    anim.SetBool("OpenDoor2", false);
                    anim.SetBool("CloseDoor2", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Kitchen Cupboard Interactions
                if (hit.collider.tag == "CupboardDoor" && cupboardDoorIsIdle == true)
                {
                    cupboardDoorIsIdle = false;
                    cupboardDoorIsOpen = true;
                    cupboardDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "CupboardDoor" && cupboardDoorIsOpen == true)
                {
                    cupboardDoorIsIdle = false;
                    cupboardDoorIsOpen = false;
                    cupboardDoorIsClosed = true;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", false);
                    anim.SetBool("CloseDoor", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "CupboardDoor" && cupboardDoorIsClosed == true)
                {
                    cupboardDoorIsIdle = false;
                    cupboardDoorIsOpen = true;
                    cupboardDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Kitchen Drawer Interactions
                if (hit.collider.tag == "KitchenDrawer" && kitchenDrawerIsIdle == true)
                {
                    kitchenDrawerIsIdle = false;
                    kitchenDrawerIsOpen = true;
                    kitchenDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "KitchenDrawer" && kitchenDrawerIsOpen == true)
                {
                    kitchenDrawerIsIdle = false;
                    kitchenDrawerIsOpen = false;
                    kitchenDrawerIsClosed = true;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", false);
                    anim.SetBool("CloseDrawer", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "KitchenDrawer" && kitchenDrawerIsClosed == true)
                {
                    kitchenDrawerIsIdle = false;
                    kitchenDrawerIsOpen = true;
                    kitchenDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Bedside Table Drawer Interactions
                if (hit.collider.tag == "BedsideDrawer" && bedsideTableDrawerIsIdle == true)
                {
                    bedsideTableDrawerIsIdle = false;
                    bedsideTableDrawerIsOpen = true;
                    bedsideTableDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "BedsideDrawer" && bedsideTableDrawerIsOpen == true)
                {
                    bedsideTableDrawerIsIdle = false;
                    bedsideTableDrawerIsOpen = false;
                    bedsideTableDrawerIsClosed = true;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", false);
                    anim.SetBool("CloseDrawer", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "BedsideDrawer" && bedsideTableDrawerIsClosed == true)
                {
                    bedsideTableDrawerIsIdle = false;
                    bedsideTableDrawerIsOpen = true;
                    bedsideTableDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Dressing Table Drawer Interactions
                if (hit.collider.tag == "DresserDrawer" && dressingTableDrawerIsIdle == true)
                {
                    dressingTableDrawerIsIdle = false;
                    dressingTableDrawerIsOpen = true;
                    dressingTableDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "DresserDrawer" && dressingTableDrawerIsOpen == true)
                {
                    dressingTableDrawerIsIdle = false;
                    dressingTableDrawerIsOpen = false;
                    dressingTableDrawerIsClosed = true;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", false);
                    anim.SetBool("CloseDrawer", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "DresserDrawer" && dressingTableDrawerIsClosed == true)
                {
                    dressingTableDrawerIsIdle = false;
                    dressingTableDrawerIsOpen = true;
                    dressingTableDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Desk Drawer Interaction
                if (hit.collider.tag == "DeskDrawer" && deskDrawerIsIdle == true)
                {
                    deskDrawerIsIdle = false;
                    deskDrawerIsOpen = true;
                    deskDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "DeskDrawer" && deskDrawerIsOpen == true)
                {
                    deskDrawerIsIdle = false;
                    deskDrawerIsOpen = false;
                    deskDrawerIsClosed = true;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", false);
                    anim.SetBool("CloseDrawer", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "DeskDrawer" && deskDrawerIsClosed == true)
                {
                    deskDrawerIsIdle = false;
                    deskDrawerIsOpen = true;
                    deskDrawerIsClosed = false;
                    anim.SetBool("DrawerIdle", false);
                    anim.SetBool("OpenDrawer", true);
                    anim.SetBool("CloseDrawer", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Freezer Door Interaction
                if (hit.collider.tag == "Freezer" && freezerDoorIsIdle == true)
                {
                    freezerDoorIsIdle = false;
                    freezerDoorIsOpen = true;
                    freezerDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "Freezer" && freezerDoorIsOpen == true)
                {
                    freezerDoorIsIdle = false;
                    freezerDoorIsOpen = false;
                    freezerDoorIsClosed = true;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", false);
                    anim.SetBool("CloseDoor", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "Freezer" && freezerDoorIsClosed == true)
                {
                    freezerDoorIsIdle = false;
                    freezerDoorIsOpen = true;
                    freezerDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Bin Lid Interaction
                if (hit.collider.tag == "BinLid" && binLidIsIdle == true)
                {
                    binLidIsIdle = false;
                    binLidIsOpen = true;
                    binLidIsClosed = false;
                    anim.SetBool("LidIdle", false);
                    anim.SetBool("OpenLid", true);
                    anim.SetBool("CloseLid", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "BinLid" && binLidIsOpen == true)
                {
                    binLidIsIdle = false;
                    binLidIsOpen = false;
                    binLidIsClosed = true;
                    anim.SetBool("LidIdle", false);
                    anim.SetBool("OpenLid", false);
                    anim.SetBool("CloseLid", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "BinLid" && binLidIsClosed == true)
                {
                    binLidIsIdle = false;
                    binLidIsOpen = true;
                    binLidIsClosed = false;
                    anim.SetBool("LidIdle", false);
                    anim.SetBool("OpenLid", true);
                    anim.SetBool("CloseLid", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Microwave Door Interaction
                if (hit.collider.tag == "MicrowaveDoor" && microwaveDoorIsIdle == true)
                {
                    microwaveDoorIsIdle = false;
                    microwaveDoorIsOpen = true;
                    microwaveDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "MicrowaveDoor" && microwaveDoorIsOpen == true)
                {
                    microwaveDoorIsIdle = false;
                    microwaveDoorIsOpen = false;
                    microwaveDoorIsClosed = true;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", false);
                    anim.SetBool("CloseDoor", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "MicrowaveDoor" && microwaveDoorIsClosed == true)
                {
                    microwaveDoorIsIdle = false;
                    microwaveDoorIsOpen = true;
                    microwaveDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                //Cooker Door Interactions
                if (hit.collider.tag == "CookerDoor" && cookerDoorIsIdle == true)
                {
                    cookerDoorIsIdle = false;
                    cookerDoorIsOpen = true;
                    cookerDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "CookerDoor" && cookerDoorIsOpen == true)
                {
                    cookerDoorIsIdle = false;
                    cookerDoorIsOpen = false;
                    cookerDoorIsClosed = true;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", false);
                    anim.SetBool("CloseDoor", true);
                    Debug.Log("hit: " + hit.collider.name);
                }
                else if (hit.collider.tag == "CookerDoor" && cookerDoorIsClosed == true)
                {
                    cookerDoorIsIdle = false;
                    cookerDoorIsOpen = true;
                    cookerDoorIsClosed = false;
                    anim.SetBool("DoorIdle", false);
                    anim.SetBool("OpenDoor", true);
                    anim.SetBool("CloseDoor", false);
                    Debug.Log("hit: " + hit.collider.name);
                }
            }
        }
    }

    public void InteractUI()
    {
        Ray ray2 = new Ray(transform.position, transform.forward);//Shoots raycast forward
        RaycastHit hit2;

        //Enable/Disable the UI "Letter E" to show if object is interactable
        if (Physics.Raycast(ray2, out hit2, interactDistance))
        {   //Enable UI element
            if (hit2.collider.tag == "RoomDoor")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "CupboardDoor")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "KitchenDrawer")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "BedsideDrawer")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "DresserDrawer")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "DeskDrawer")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "Freezer")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "BinLid")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "MicrowaveDoor")
            {
                interactUI.SetActive(true);
            }
            else if (hit2.collider.tag == "CookerDoor")
            {
                interactUI.SetActive(true);
            }
		
			else if (hit2.collider.tag == "LeaveSceneTrigger")
            {
                interactUI.SetActive(true);
                leaveCrimeSceneText.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
					InteractScipt.SetTypeOfInteraction("LeaveScene",hit2.transform.gameObject);
                  	
                }
            }
            //Disable UI element
            else
            {
                interactUI.SetActive(false);
                leaveCrimeSceneText.SetActive(false);
            }
			Debug.Log("trying to look at " +hit2.collider.gameObject.name );
			for(int i =0; i<GameObject.Find("MurderManager").GetComponent<TutLevelManager>().CluesNeeded.Count;i++){
				if (hit2.collider.gameObject.name  == GameObject.Find("MurderManager").GetComponent<TutLevelManager>().CluesNeeded[i])
				{interactUI.SetActive(true);
					if (Input.GetKeyDown("e"))
					{
						InteractScipt.SetTypeOfInteraction("LookAtClue",hit2.transform.gameObject);
						
					}
				}
			}
        }
    }
}
