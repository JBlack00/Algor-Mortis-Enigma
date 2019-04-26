using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OfficeNavController : MonoBehaviour {
	public List<GameObject> UIObjectsOnscreen;
	public List<GameObject> UIObjectsInNavBar;
	public List<GameObject> UIObjectsInContainer;
	[SerializeField]
	public  List<Sprite> images;
	public List<Report> Reports;

	//public Report[] Reports;
	[SerializeField]
	private int CurReport;
	private int CurPage;	
	
	public GameObject ManagerScript;
	public SaveToText saveScript;
	[System.Serializable]
	public class Report{
		public Sprite ProfilePic;
		public string name;
		public string Aliases;
		public string Birthday;
		public string Gender;
		public string Height;
		public string Weight;
		
		public string Personal;
		
		public bool Visable;
		
		public Report(string newName, string newAliases, string newBirthday,string newGender, string newHeight, string newWeight,string newPersonal){
			name = newName;
			Aliases = newAliases;
			Birthday = newBirthday;
			Gender = newGender;
			Height = newHeight;
			Weight = newWeight;
			Personal = newPersonal;
			
			Visable = false;
			
			ProfilePic = GetRandomPic();
		}
		public string StringToName(string newString){
			return newString;
		}
		public Sprite GetRandomPic(){
			int RandomNumber = Random.Range (0, GameObject.FindGameObjectWithTag ("LaptopScreen").GetComponent<OfficeNavController> ().images.Count );
			Sprite newPic= GameObject.FindGameObjectWithTag ("LaptopScreen").GetComponent<OfficeNavController> ().images [RandomNumber];
			GameObject.FindGameObjectWithTag ("LaptopScreen").GetComponent<OfficeNavController> ().images.RemoveAt (RandomNumber);
			return newPic;
		}
	}
	
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{

		//if (SceneManager.GetActiveScene().name == "DetectiveOffice")
		//{
		//    ManagerScript = GameObject.Find("MurderManager");
		//    saveScript = ManagerScript.GetComponent<SaveToText>();
		//    GameObject temp = GameObject.Find("LaptopScreen"); 
		
		//    //laptop screen objs
		//    for (int i = 0; i < gameObject.transform.childCount; i++)
		//    {
		//        UIObjectsOnscreen.Add(gameObject.transform.GetChild(i).gameObject);
		//    }
		//    //anything scrollable UI
		//    for (int i = 0; i < UIObjectsOnscreen[0].transform.GetChild(0).transform.GetChild(0).gameObject.transform.childCount; i++)
		//    {
		//        UIObjectsInContainer.Add(UIObjectsOnscreen[0].transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).gameObject);
		//    }
		//    //navbar objects
		//    for (int i = 0; i < UIObjectsOnscreen[1].transform.GetChild(0).gameObject.transform.childCount; i++)
		//    {
		//        UIObjectsInNavBar.Add(UIObjectsOnscreen[1].transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
		//    }
		//    for (int i = 0; i <6; i++)
		//    {
		//        if (saveScript.ReadString("Statements/Statement" + (CurReport + 1) + ".txt")[1] == "StatementFound")
		//        {
		
		//            UIObjectsInContainer[3].transform.GetChild(0).GetChild(CurReport).GetChild(5).GetComponent<Button>().interactable = false;
		//            Debug.Log("Curent report = " + CurReport);
		//        }
		//    }
		//}
	}
	
	// Use this for initializations
	void Awake () {
		ManagerScript = GameObject.Find("MurderManager");
		saveScript = ManagerScript.GetComponent<SaveToText>();
		
		//laptop screen objs
		for(int i =0; i< gameObject.transform.childCount;i++){
			UIObjectsOnscreen.Add (gameObject.transform.GetChild(i).gameObject);
		}
		//anything scrollable UI
		for(int i =0; i< UIObjectsOnscreen[0].transform.GetChild(0).transform.GetChild(0).gameObject.transform.childCount;i++){
			UIObjectsInContainer.Add (UIObjectsOnscreen[0].transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).gameObject);
		}
		//navbar objects
		for(int i =0; i< UIObjectsOnscreen[1].transform.GetChild(0).gameObject.transform.childCount;i++){
			UIObjectsInNavBar.Add (UIObjectsOnscreen[1].transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
		}
		SaveToText temp = ManagerScript.GetComponent<SaveToText>();
		
		for (int i = 0; i < 6; i++)
		{
			CurReport = i;
			if (saveScript.ReadStringLine("Statements/Statement" + (CurReport + 1) + ".txt",1) == "StatementFound")
			{
				
				UIObjectsInContainer[3].transform.GetChild(0).GetChild(CurReport).GetChild(5).GetComponent<Button>().interactable = false;
				Debug.Log("Curent report = " + CurReport);
			}
		}
		//CreateNewReport (temp.ReadString("ReportTest.txt")[0],temp.ReadString("ReportTest.txt")[1],temp.ReadString("ReportTest.txt")[2],temp.ReadString("ReportTest.txt")[3],temp.ReadString("ReportTest.txt")[4],temp.ReadString("ReportTest.txt")[5]);
		//Debug.Log (Reports[0].ToString());
		//SetReportToUI (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (CurReport == Reports.Count - 1) {
			UIObjectsInContainer [2].transform.GetChild (1).GetComponent<Button> ().interactable = false;
		}else {
			UIObjectsInContainer [2].transform.GetChild (1).GetComponent<Button> ().interactable = true;
		}
		if (CurReport == 0) {
			UIObjectsInContainer [2].transform.GetChild (0).GetComponent<Button> ().interactable = false;
			UIObjectsInContainer [0].SetActive (true);
		} else {
			UIObjectsInContainer [2].transform.GetChild (0).GetComponent<Button> ().interactable = true;
		}
		
		if (CurPage == 0) {
			UIObjectsInNavBar[0].GetComponent<Button>().interactable = false;
		}else {
			UIObjectsInNavBar[0].GetComponent<Button>().interactable = true;
		}
		if (CurPage >0) {
			UIObjectsInNavBar[1].GetComponent<Button>().interactable = false;
		} else {
			UIObjectsInNavBar[1].GetComponent<Button>().interactable = true;
		}
		if (UIObjectsInContainer [2].transform.GetChild (1).gameObject.activeInHierarchy ==false) {
			UIObjectsInNavBar[2].transform.GetChild(0).GetComponent<Text>().text = "https://www.CrimeUnitNY.gov";
		}else{
			UIObjectsInNavBar[2].transform.GetChild(0).GetComponent<Text>().text = "https://www.CrimeUnitNY.gov/" + "CrimeReport/" + Reports[CurReport].name;
		}
		
		SetReportToUI (CurReport);
	}
	public void CreateNewReport(string newName, string newAliases, string newBirthday, string newHeight, string newWeight,string newGender,string newPersonal){
		Reports.Add (new Report (newName, newAliases, newBirthday, newGender, newHeight, newWeight,newPersonal));
	}
	void SetReportToUI(int ReportNum){
		string[] reportNameUIElements = new string[]{Reports[ReportNum].name,Reports[ReportNum].Aliases,Reports[ReportNum].Birthday,Reports[ReportNum].Height,Reports[ReportNum].Weight,Reports[ReportNum].Gender};
		//setting reports
		for (int i =0; i< UIObjectsInContainer[1].transform.childCount; i++) {
			Text Element= UIObjectsInContainer[1].transform.GetChild(3).GetChild(i).GetChild(0).GetComponent<Text>();
			Element.text = Reports[ReportNum].StringToName(reportNameUIElements[i]);
		}
		UIObjectsInContainer [1].transform.GetChild (4).GetChild (1).GetComponent<Text> ().text = Reports [ReportNum].Personal;
		UIObjectsInContainer [1].transform.GetChild (1).GetComponent<Image> ().sprite = Reports [ReportNum].ProfilePic;
		
		//setting reportStatments
		UIObjectsInContainer [1].transform.GetChild (5).GetChild (1).GetComponent<Text> ().text = GetCurStatment (CurReport);
		
		//setting suspects
		for (int i =0; i< UIObjectsInContainer [3].transform.GetChild (0).childCount; i++) {
			string SuspectNum = UIObjectsInContainer [3].transform.GetChild (0).GetChild (i).name.Substring(UIObjectsInContainer [3].transform.GetChild (0).GetChild (0).name.Length - 1);
			//Debug.Log (SuspectNum + " SuspectNum");
			Text Element2= UIObjectsInContainer [3].transform.GetChild (0).GetChild (i).GetChild(1).GetChild(0).GetComponent<Text>();
			Element2.text = Reports[i].name;
			UIObjectsInContainer [3].transform.GetChild (0).GetChild (i).GetChild(4).GetComponent<Image>().sprite = Reports[i].ProfilePic;
		}

		//setting autopsy report
		if (UIObjectsInContainer [1].activeSelf == false && UIObjectsInContainer [4].activeSelf ==true) {
			if(CurPage == 0){
				UIObjectsInContainer [4].SetActive(false);
			}
		}

	}
	public string GetCurStatment(int CurReport){
		if (saveScript.ReadStringLine ("Statements/Statement" + (CurReport + 1) + ".txt",1)  == "StatementFound") {
			
			return saveScript.ReadStringLine ("Statements/Statement" + (CurReport + 1) + ".txt",0);
		} else {
			return "(No statement given yet)";
		}
		
	}
	public void LastReport(){
		CurReport = CurReport - 1;
	}
	public void NextReport(){
		CurReport = CurReport + 1;
	}
	public void LastPage(){
		UIObjectsInContainer [1].SetActive (false);
		UIObjectsInContainer [2].SetActive (false);
		UIObjectsInContainer [3].SetActive (true);
		CurPage = CurPage - 1;
	}
	public void RestorePage(){
		CurPage = CurPage + 1;
	}
	public void OpenReport(GameObject obj){
		UIObjectsInContainer [0].SetActive (false);
		UIObjectsInContainer [1].SetActive (true);
		UIObjectsInContainer [2].SetActive (true);
		UIObjectsInContainer [3].SetActive (false);
		for (int i =0; i< Reports.Count; i++) {
			if (obj.transform.parent.name == "Suspect" + i){
				CurReport = i;
			}
		}
		
		CurPage ++;
	}
	public void GetStatement(GameObject obj){
		for (int i =0; i< Reports.Count; i++) {
			if (obj.transform.parent.name == "Suspect" + i){
				CurReport = i;
				saveScript.WriteStringLine ("StatementFound",1,"Statements/Statement" + (i+1) +".txt");
			}
		}
		CurPage ++;
	}
	public void OpenAutopsyReport(GameObject obj){
		UIObjectsInContainer [0].SetActive (false);
		UIObjectsInContainer [4].SetActive (true);
		UIObjectsInContainer [3].SetActive (false);
		CurPage ++;
	}
	public void SendToCourt(GameObject obj){	
		if (obj.GetComponent<Text> ().text == GameObject.Find ("MurderManager").GetComponent<RandomMurdererController> ().Murderer) {
			if (GameObject.Find ("MurderManager").GetComponent<RandomMurdererController> ().Murderer == "suicide"){
				GameObject.Find("PlayerUI").transform.GetChild(5).gameObject.SetActive(true);
				GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "Innocent";
				GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "You choose an innocent person, Thanks for playing our prototype";
			}
			GameObject.Find("PlayerUI").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "Guilty";
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "You found out the Murderer, Thanks for playing our prototype";
		} else {
			GameObject.Find("PlayerUI").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "Innocent";
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "You choose an innocent person, Thanks for playing our prototype";
		}
	}
	public void MarkAsSuicide(){	
		if (GameObject.Find ("MurderManager").GetComponent<RandomMurdererController> ().Murderer == "suicide"){
			GameObject.Find("PlayerUI").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "Suicide";
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "You found out the truth, Thanks for playing our prototype";
		} else {
			Debug.Log(GameObject.Find ("MurderManager").GetComponent<RandomMurdererController> ().Murderer + "  " + "suicide");
			GameObject.Find("PlayerUI").transform.GetChild(5).gameObject.SetActive(true);
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "Murder";
			GameObject.Find("PlayerUI").transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "You let a murderer go free, Thanks for playing our prototype";
		}
	}
	void FakeLeaveRoom(){
		
	}
	
}
