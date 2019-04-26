using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour {
	public string[] SceneTypes = new string[]{"TUT", "NYapp","Alleyway", "BigApp", "Church"};
	public string thisScene;
	public string[] SaveText = new string[1];
	public Texture2D[] allSceneCluePic;
	// Use this for initialization
	void Awake(){

	}
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene ().name == "DetectiveOffice") {
			SetRandomCrime();
			Debug.Log ("SetRandomCrime is calling");
			if (GameObject.Find ("MurderManager").GetComponent<SaveToText> ().ReadStringLine ("GameStatus.txt",0) == "New") {
			
					//SetRandomCrime();
					
					Debug.Log ("Setting new crime in Scene controller");
					

			}
		}
	}
	void Start () {
		//ReadPlayerStats ();
		//CHANGE IN NEXT FULL VERSION
		//SetRandomCrime();
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(FindObjectsOfType(GetType())[1]);
		}

		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnApplicationQuit()
	{
		GetComponent<SaveToText> ().WriteStringLine ("New",0,"GameStatus.txt");
	}
	void ReadPlayerStats(){
		SaveText[0] = GameObject.Find ("MurderManager").GetComponent<SaveToText>().ReadStringLine("PlayerManager.txt",0);
		if (SaveText[0] == "TUTDone") {
			SetRandomCrime();
		}
	}
 
    void SetRandomCrime(){
		//thisScene = SceneTypes [Random.Range (0, SceneTypes.Length)];
		thisScene = SceneTypes [0];
		OfficeNavController Report = GameObject.FindGameObjectWithTag("LaptopScreen").GetComponent<OfficeNavController>();
		SaveToText temp = GameObject.Find ("MurderManager").GetComponent<SaveToText>();
		switch(thisScene){
		case "TUT":
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate1.txt",0),temp.ReadStringLine("ReportTemplate1.txt",1),temp.ReadStringLine("ReportTemplate1.txt",2),temp.ReadStringLine("ReportTemplate1.txt",3),temp.ReadStringLine("ReportTemplate1.txt",4),temp.ReadStringLine("ReportTemplate1.txt",5),temp.ReadStringLine("ReportTemplate1.txt",6));
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate2.txt",0),temp.ReadStringLine("ReportTemplate2.txt",1),temp.ReadStringLine("ReportTemplate2.txt",2),temp.ReadStringLine("ReportTemplate2.txt",3),temp.ReadStringLine("ReportTemplate2.txt",4),temp.ReadStringLine("ReportTemplate2.txt",5),temp.ReadStringLine("ReportTemplate2.txt",6));
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate3.txt",0),temp.ReadStringLine("ReportTemplate3.txt",1),temp.ReadStringLine("ReportTemplate3.txt",2),temp.ReadStringLine("ReportTemplate3.txt",3),temp.ReadStringLine("ReportTemplate3.txt",4),temp.ReadStringLine("ReportTemplate3.txt",5),temp.ReadStringLine("ReportTemplate3.txt",6));
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate4.txt",0),temp.ReadStringLine("ReportTemplate4.txt",1),temp.ReadStringLine("ReportTemplate4.txt",2),temp.ReadStringLine("ReportTemplate4.txt",3),temp.ReadStringLine("ReportTemplate4.txt",4),temp.ReadStringLine("ReportTemplate4.txt",5),temp.ReadStringLine("ReportTemplate4.txt",6));
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate5.txt",0),temp.ReadStringLine("ReportTemplate5.txt",1),temp.ReadStringLine("ReportTemplate5.txt",2),temp.ReadStringLine("ReportTemplate5.txt",3),temp.ReadStringLine("ReportTemplate5.txt",4),temp.ReadStringLine("ReportTemplate5.txt",5),temp.ReadStringLine("ReportTemplate5.txt",6));
			Report.CreateNewReport(temp.ReadStringLine("ReportTemplate6.txt",0),temp.ReadStringLine("ReportTemplate6.txt",1),temp.ReadStringLine("ReportTemplate6.txt",2),temp.ReadStringLine("ReportTemplate6.txt",3),temp.ReadStringLine("ReportTemplate6.txt",4),temp.ReadStringLine("ReportTemplate6.txt",5),temp.ReadStringLine("ReportTemplate6.txt",6));
			Debug.Log(" report 1 = " + Report.Reports[0].name) ;
			break;
		case "NYapp":
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate1.txt", 0), temp.ReadStringLine("ReportTemplate1.txt", 1), temp.ReadStringLine("ReportTemplate1.txt", 2), temp.ReadStringLine("ReportTemplate1.txt", 3), temp.ReadStringLine("ReportTemplate1.txt", 4), temp.ReadStringLine("ReportTemplate1.txt", 5), temp.ReadStringLine("ReportTemplate1.txt", 6));
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate2.txt", 0), temp.ReadStringLine("ReportTemplate2.txt", 1), temp.ReadStringLine("ReportTemplate2.txt", 2), temp.ReadStringLine("ReportTemplate2.txt", 3), temp.ReadStringLine("ReportTemplate2.txt", 4), temp.ReadStringLine("ReportTemplate2.txt", 5), temp.ReadStringLine("ReportTemplate2.txt", 6));
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate3.txt", 0), temp.ReadStringLine("ReportTemplate3.txt", 1), temp.ReadStringLine("ReportTemplate3.txt", 2), temp.ReadStringLine("ReportTemplate3.txt", 3), temp.ReadStringLine("ReportTemplate3.txt", 4), temp.ReadStringLine("ReportTemplate3.txt", 5), temp.ReadStringLine("ReportTemplate3.txt", 6));
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate4.txt", 0), temp.ReadStringLine("ReportTemplate4.txt", 1), temp.ReadStringLine("ReportTemplate4.txt", 2), temp.ReadStringLine("ReportTemplate4.txt", 3), temp.ReadStringLine("ReportTemplate4.txt", 4), temp.ReadStringLine("ReportTemplate4.txt", 5), temp.ReadStringLine("ReportTemplate4.txt", 6));
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate5.txt", 0), temp.ReadStringLine("ReportTemplate5.txt", 1), temp.ReadStringLine("ReportTemplate5.txt", 2), temp.ReadStringLine("ReportTemplate5.txt", 3), temp.ReadStringLine("ReportTemplate5.txt", 4), temp.ReadStringLine("ReportTemplate5.txt", 5), temp.ReadStringLine("ReportTemplate5.txt", 6));
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate6.txt", 0), temp.ReadStringLine("ReportTemplate6.txt", 1), temp.ReadStringLine("ReportTemplate6.txt", 2), temp.ReadStringLine("ReportTemplate6.txt", 3), temp.ReadStringLine("ReportTemplate6.txt", 4), temp.ReadStringLine("ReportTemplate6.txt", 5), temp.ReadStringLine("ReportTemplate6.txt", 6));
                break;
		case "Alleyway":
			break;
		case "BigApp":
             Report.CreateNewReport(temp.ReadStringLine("ReportTemplate1.txt", 0), temp.ReadStringLine("ReportTemplate1.txt", 1), temp.ReadStringLine("ReportTemplate1.txt", 2), temp.ReadStringLine("ReportTemplate1.txt", 3), temp.ReadStringLine("ReportTemplate1.txt", 4), temp.ReadStringLine("ReportTemplate1.txt", 5), temp.ReadStringLine("ReportTemplate1.txt", 6));
                Report.CreateNewReport(temp.ReadStringLine("ReportTemplate2.txt", 0), temp.ReadStringLine("ReportTemplate2.txt", 1), temp.ReadStringLine("ReportTemplate2.txt", 2), temp.ReadStringLine("ReportTemplate2.txt", 3), temp.ReadStringLine("ReportTemplate2.txt", 4), temp.ReadStringLine("ReportTemplate2.txt", 5), temp.ReadStringLine("ReportTemplate2.txt", 6));
                Report.CreateNewReport(temp.ReadStringLine("ReportTemplate3.txt", 0), temp.ReadStringLine("ReportTemplate3.txt", 1), temp.ReadStringLine("ReportTemplate3.txt", 2), temp.ReadStringLine("ReportTemplate3.txt", 3), temp.ReadStringLine("ReportTemplate3.txt", 4), temp.ReadStringLine("ReportTemplate3.txt", 5), temp.ReadStringLine("ReportTemplate3.txt", 6));
                Report.CreateNewReport(temp.ReadStringLine("ReportTemplate4.txt", 0), temp.ReadStringLine("ReportTemplate4.txt", 1), temp.ReadStringLine("ReportTemplate4.txt", 2), temp.ReadStringLine("ReportTemplate4.txt", 3), temp.ReadStringLine("ReportTemplate4.txt", 4), temp.ReadStringLine("ReportTemplate4.txt", 5), temp.ReadStringLine("ReportTemplate4.txt", 6));
                Report.CreateNewReport(temp.ReadStringLine("ReportTemplate5.txt", 0), temp.ReadStringLine("ReportTemplate5.txt", 1), temp.ReadStringLine("ReportTemplate5.txt", 2), temp.ReadStringLine("ReportTemplate5.txt", 3), temp.ReadStringLine("ReportTemplate5.txt", 4), temp.ReadStringLine("ReportTemplate5.txt", 5), temp.ReadStringLine("ReportTemplate5.txt", 6));
                Report.CreateNewReport(temp.ReadStringLine("ReportTemplate6.txt", 0), temp.ReadStringLine("ReportTemplate6.txt", 1), temp.ReadStringLine("ReportTemplate6.txt", 2), temp.ReadStringLine("ReportTemplate6.txt", 3), temp.ReadStringLine("ReportTemplate6.txt", 4), temp.ReadStringLine("ReportTemplate6.txt", 5), temp.ReadStringLine("ReportTemplate6.txt", 6));

                break;
		case "Church":
			break;
		}
	}

}
