using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour {
	public FadeToBlack FadeScript;
    public ClueMarker ClueMarkScript;
	public PlayerInteractions PlayerScipt;
	public LookAtClueClose LookatClueScript;
	public OfficeAnimationManager OfficeAnimationManagerScript;
    public CameraSnapShot CameraSnapShotScript;

    public GameObject NewInvontoryItem;
    public Transform TitlePos;

    public List<InstaInteraction> InstaInteractions;
    public List<WaitInteraction> WaitInteractions;
	public List<string> InstaInteractionsCheckList;
    public List<string> WaitInteractionsCheckList;

    [System.Serializable]
	public class WaitInteraction{
		public float Timer;
		public bool Done;
       
		public WaitInteraction(float newTimer){
			Timer = newTimer;
			Done = false;
          
        } 
    }
    [System.Serializable]
    public class InstaInteraction
    {   public bool Done;
        public GameObject InteractableObject;
        public InstaInteraction(GameObject NewObj)
        { 
          InteractableObject = NewObj;
			Done=true;
        }
    }
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
       
        if (TitlePos == null)
        {

            TitlePos = GameObject.Find("UISpawnPos").transform;
            TitlePos.gameObject.SetActive(false);
            TitlePos.parent.GetComponent<Image>().enabled = true;
        }
        else
        {
            TitlePos = GameObject.Find("UISpawnPos").transform;
            TitlePos.gameObject.SetActive(false);
            TitlePos.parent.GetComponent<Image>().enabled = true;
        }
        NewInvontoryItem= Resources.Load("Prefabs/item", typeof(GameObject)) as GameObject;

        FadeScript = GameObject.Find ("FullScreenOverlay").GetComponent<FadeToBlack> ();
		if (GameObject.Find ("FPSCamera") != null) {
			PlayerScipt = GameObject.Find ("FPSCamera").GetComponent<PlayerInteractions> ();
			LookatClueScript = GameObject.Find ("FPSCamera").GetComponent<LookAtClueClose> ();
            CameraSnapShotScript = GameObject.Find("FPSCamera").GetComponent<CameraSnapShot>();

        }
		if (GameObject.Find ("Main Camera") != null) {
			OfficeAnimationManagerScript = GameObject.Find ("Main Camera").GetComponent<OfficeAnimationManager> ();
		}
        

    }
	// Use this for initialization
	void Start () {
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (WaitInteractions.Count > 0) {
			CheckWaitInteractions();
		}
		if (InstaInteractions.Count > 0) {
			CheckInstaInteractions();
		}
	}
	public void CheckWaitInteractions(){
		//if(PlayerScipt)
		for (int i =0; i < WaitInteractions.Count; i++) {
            WaitInteractions[i].Timer = WaitInteractions[i].Timer -Time.deltaTime;
			if(WaitInteractions[i].Timer <=0){
                WaitInteractions[i].Done =true;
			}
			if(WaitInteractions[i].Done){
				DoWaitInteraction(WaitInteractionsCheckList[i]);
			}
		}
	}
	public void CheckInstaInteractions(){
		//if(PlayerScipt)
		for (int i =0; i <InstaInteractions.Count; i++) {
			DoInstaInteraction(InstaInteractionsCheckList[i]);
			InstaInteractions.RemoveAt(i);
			InstaInteractionsCheckList.RemoveAt(i);
		}
	}

	
	private void DoInstaInteraction(string InteractionString){
		switch (InteractionString) {
		case "PlaceMarker":
			ClueMarkScript.PlaceMarker ();
			break;
		case "LookAtClue":
			//ClueMarkScript.PlaceMarker();
			LookatClueScript.SetCurrentClue(InstaInteractions[InstaInteractionsCheckList.Count-1].InteractableObject.name);
			PlayerScipt.state =1;
			PlayerScipt.LookAtUI.SetActive(true);
//			Debug.Log(InstaInteractions[InstaInteractionsCheckList.Count-1].InteractableObject.name);
			break;
		case "RemoveLookAtClue":
			//ClueMarkScript.PlaceMarker();
			PlayerScipt.state =0;
			PlayerScipt.LookAtUI.SetActive(false);
			//			Debug.Log(InstaInteractions[InstaInteractionsCheckList.Count-1].InteractableObject.name);
			break;
		case "AddToInvo":
			GameObject temp = GameObject.Find("MurderManager");
			bool DoAdd = true;
			for(int i=0; i<temp.GetComponent<inventory>().invo.clueNames.Count;i++){
				if(temp.GetComponent<inventory>().invo.clueNames[i] == LookatClueScript.GetCurrentClue().name){
					DoAdd = false;
				}
			}
			if(DoAdd){
			    temp.GetComponent<inventory>().invo.clueNames.Add(LookatClueScript.GetCurrentClue().name);
                GameObject newItem = Instantiate(NewInvontoryItem, new Vector3(TitlePos.position.x, TitlePos.position.y-(120* (TitlePos.parent.transform.childCount-2)), TitlePos.position.z), Quaternion.identity, TitlePos.parent);
                newItem.name = "item(" + LookatClueScript.GetCurrentClue().name + ")";
                    newItem.transform.GetChild(1).GetComponent<Text>().text = LookatClueScript.GetCurrentClue().name;
                     newItem.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate{GameObject.Find("Canvas").GetComponent<UIinventory>().RemoveObjectFromInvo(newItem); });
                    //newItem.transform.GetComponentInChildren<Button>().onClick.AddListener((delegate { RemoveObjectFromInvo(this.gameObject); }));
                    Debug.Log(" found it" +newItem.transform.GetComponentInChildren<Button>());
                }
                else{
				//invo allready has this item

			}
			break;
            case "AddClueToInvo":

                GameObject.Find("MurderManager").GetComponent<inventory>().invo.clueNames.Add(" MurderClue ");
                GameObject newItem2 = Instantiate(NewInvontoryItem, new Vector3(TitlePos.position.x, TitlePos.position.y - (120 * (TitlePos.parent.transform.childCount - 2)), TitlePos.position.z), Quaternion.identity, TitlePos.parent);
                newItem2.name = "item(" +" MurderClue "+ ")";
                newItem2.transform.GetChild(1).GetComponent<Text>().text = " MurderClue ";
                newItem2.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { GameObject.Find("Canvas").GetComponent<UIinventory>().RemoveObjectFromInvo(newItem2); });
                    //newItem.transform.GetComponentInChildren<Button>().onClick.AddListener((delegate { RemoveObjectFromInvo(this.gameObject); }));
                    Debug.Log(" found it" + newItem2.transform.GetComponentInChildren<Button>());
            
                break;
            case "TakePicture":
                CameraSnapShotScript.TakePhoto();
                Debug.Log("SnapShot Took");
                break;
        }
	}
    
    private void DoWaitInteraction(string InteractionString)
    {
        switch (InteractionString)
        {
            case "LeaveScene":
                WaitInteractions.RemoveAt(0);
                WaitInteractionsCheckList.RemoveAt(0);
                GameObject.Find("Camera&Controller").GetComponent<vp_FPInput>().MouseCursorForced = true;
                SceneManager.LoadScene("DetectiveOffice");
                break;
            case "FakeLeaveRoom":
                WaitInteractions.RemoveAt(0);
                WaitInteractionsCheckList.RemoveAt(0);
                SceneManager.LoadScene("DetectiveOffice");
                break;
        }
    }
	public void SetTypeOfInteraction(string InteractionString, GameObject obj){
		switch (InteractionString) {
			case "LeaveScene":
                WaitInteractions.Add( new WaitInteraction(2f));
                WaitInteractionsCheckList.Add("LeaveScene");
			    FadeScript.SetTimeToFade(true);
			break;
            case "PlaceMarker":
                InstaInteractions.Add(new InstaInteraction(obj));
                InstaInteractionsCheckList.Add("PlaceMarker");
            break;
			case "LookAtClue":
				InstaInteractions.Add(new InstaInteraction(obj));
				InstaInteractionsCheckList.Add("LookAtClue");
			break;
			case "RemoveLookAtClue":
				InstaInteractions.Add(new InstaInteraction(obj));
				InstaInteractionsCheckList.Add("RemoveLookAtClue");
			break;
			case "AddToInvo":
				InstaInteractions.Add(new InstaInteraction(obj));
				InstaInteractionsCheckList.Add("AddToInvo");
			break;
            case "AddClueToInvo":
                InstaInteractions.Add(new InstaInteraction(obj));
                InstaInteractionsCheckList.Add("AddClueToInvo");
                break;
            case "FakeLeaveRoom":
				WaitInteractions.Add(new WaitInteraction(2f));
				WaitInteractionsCheckList.Add("FakeLeaveRoom");
				FadeScript.SetTimeToFade(true);
				OfficeAnimationManagerScript.LookAtDoor(false);
			break;
            case "TakePicture":
                InstaInteractions.Add(new InstaInteraction(obj));
                InstaInteractionsCheckList.Add("TakePicture");
                break;
        }
	}


}
