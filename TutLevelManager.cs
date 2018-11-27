using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutLevelManager : MonoBehaviour {
    public string[] PossibleMurders = { "HusbandMurder", "suicide", "FamilyMurder", "WifeMurder" };
    public List<string> CluesNeeded = new List<string>();
    public string thisMurder;
	public Object[] reports;
	//public CrimeSceneController CrimeSceneConScript;
	// Use this for initialization
	void Start () {
		//CrimeSceneConScript = GameObject.Find ("CrimeSceneConScript").GetComponent<CrimeSceneController>();
	
	}
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene ().name != "MainMenu") {
			if (GetComponent<SaveToText> ().ReadStringLine ("GameStatus.txt",1) == "NoClue") {
				GetComponent<SaveToText> ().WriteStringLine ("CluesActive",1,"GameStatus.txt");
			thisMurder = PickRndMurder ();
			Debug.Log ("tut murder is " + thisMurder);
			GetListOfCluesNeeded (); 
			}else{
				Debug.Log (GetComponent<SaveToText> ().ReadStringLine ("GameStatus.txt",0));
			}
		}
		if (SceneManager.GetActiveScene ().name != "DetectiveOffice") {
			//reports = GameObject.Find ("LaptopScreen").GetComponent<OfficeNavController>().Reports;
		}
	}
	void OnApplicationQuit()
	{
		GetComponent<SaveToText> ().WriteStringLine ("NoClue",1,"GameStatus.txt");
		for(int i =0; i< 6;i++){
			GetComponent<SaveToText> ().WriteStringLine ("NoStatement",1,"Statements/Statement" + (i +1) +".txt");
			Debug.Log ("Statements/Statement" + (i +1) +".txt");
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
    private string PickRndMurder()
    {
        int RND = Random.Range(3,3);
        switch (RND)
        {
            case 0:
                return PossibleMurders[0];
                break;
            case 1:
                return PossibleMurders[1];
                break;
            case 2:
                return PossibleMurders[2];
                break;
            case 3:
                return PossibleMurders[3];
                break;
            default:
                return PossibleMurders[0];
                break;
        }
        
    }

    private void GetListOfCluesNeeded()
    {//if statment is needed to to unity complie system 
     /*  switch (thisMurder)
       {
           case PossibleMurders[0]:
               CluesNeeded.Add("knife");
               CluesNeeded.Add("suicide_note");
               CluesNeeded.Add("Check_veins"); 
               break;
           case PossibleMurders[1]:
               CluesNeeded.Add("bruised_neck");
               CluesNeeded.Add("finger_Prints");
               CluesNeeded.Add("Phone_texts");
               break;
           case PossibleMurders[2]:
               CluesNeeded.Add("gas_hose");
               CluesNeeded.Add("Body_position");
               CluesNeeded.Add("Autopsy");
               break;
           case PossibleMurders[3]:
               CluesNeeded.Add("check_throat");
               CluesNeeded.Add("fake_suicide_note");
               CluesNeeded.Add( "footprints");
               break;
           default:
               CluesNeeded.Add("knife");
               CluesNeeded.Add("suicide_note");
               CluesNeeded.Add("Check_veins");
               break;
       }*/
        if (thisMurder == PossibleMurders[0])
        {
			CluesNeeded.Add("Knife");
			CluesNeeded.Add("WineGlass");
			CluesNeeded.Add("Phone");
			GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario1");
		
		}
        else if (thisMurder == PossibleMurders[1])
        {
            CluesNeeded.Add("Autopsy");
			CluesNeeded.Add("SuicideNote");
			CluesNeeded.Add("WineGlass");
			GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario2");

		}
        else if (thisMurder == PossibleMurders[2])
        {
            CluesNeeded.Add("Gun");
			CluesNeeded.Add("Blood");
			CluesNeeded.Add("ChalkOutlines");
			GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario3");

		}
        else if (thisMurder == PossibleMurders[3])
        {
			CluesNeeded.Add("Ashtray");
            CluesNeeded.Add("Blood");
            //CluesNeeded.Add("Missing_rug");
            CluesNeeded.Add("Witness");
			GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic =Resources.LoadAll<Sprite>("ClueImages/Scenario4");
		}

        for (int i = 0; i < CluesNeeded.Count; i++)
        {
            Debug.Log("clues needed in this level " + CluesNeeded[i].ToString());
        }

    }
}
