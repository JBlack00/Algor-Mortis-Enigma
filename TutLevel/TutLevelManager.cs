using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutLevelManager : MonoBehaviour {
	public string[] PossibleMurders = { "HusbandMurder", "suicide", "FamilyMurder", "WifeMurder" };
    public List<string> CluesNeeded = new List<string>();
    public string thisMurder;
	//public Object[] reports;
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
		if (SceneManager.GetActiveScene ().name == "DetectiveOffice") {
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
        int RND = Random.Range(0,3);
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
			//GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario1");
			SetStatements(0);
		}
        else if (thisMurder == PossibleMurders[1])
        {
            CluesNeeded.Add("Autopsy");
			CluesNeeded.Add("SuicideNote");
			CluesNeeded.Add("WineGlass");
			//GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario2");
			SetStatements(1);
		}
        else if (thisMurder == PossibleMurders[2])
        {
            CluesNeeded.Add("Gun");
			CluesNeeded.Add("Blood");
			CluesNeeded.Add("ChalkOutlines");
			//GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Sprite>("ClueImages/Scenario3");
			SetStatements(2);
		}
        else if (thisMurder == PossibleMurders[3])
        {
			CluesNeeded.Add("Ashtray");
            CluesNeeded.Add("Blood");
            //CluesNeeded.Add("Missing_rug");
            CluesNeeded.Add("Witness");
			//GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic =Resources.LoadAll<Sprite>("ClueImages/Scenario4");
			SetStatements(3);
		}

        for (int i = 0; i < CluesNeeded.Count; i++)
        {
            Debug.Log("clues needed in this level " + CluesNeeded[i].ToString());
        }

    }

	void SetStatements(int MurderNumber){
		SaveToText SaveToTextScript = GetComponent<SaveToText> ();
		string MurderStatement = "";
		string WitnessStatement = "";
		switch(MurderNumber){
		case 0:
			MurderStatement = "I just got there and he was dead. I know he was cheating on me we had an open relationship";
			WitnessStatement = "I heard loud arguing and shouting last night";
			for(int i =1; i< 7;i++){
				SaveToTextScript.WriteStringLine( GetRandomNonHelpfulStatement(),0,"Statements/Statement" + i+".txt");
				Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
				if(i-1 == GetComponent<RandomMurdererController>().RNGMurder){
					SaveToTextScript.WriteStringLine(MurderStatement,0,"Statements/Statement" + i+".txt");
					if(GetComponent<RandomMurdererController>().RNGMurder ==6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i-1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder ==0){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder !=0 && GetComponent<RandomMurdererController>().RNGMurder !=6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
				}
			}
			break;
		case 1:
			MurderStatement = "Listen I left her alive... She liked it... You know, rough, I did not mind it got her off but I swear she was fine after. I...I can't believe shes dead.";
			WitnessStatement = "I saw a tall dark-haired man leaving there apartment ";
			for(int i =1; i< 7;i++){
				SaveToTextScript.WriteStringLine( GetRandomNonHelpfulStatement(),0,"Statements/Statement" + i+".txt");
				Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
				if(i-1 == GetComponent<RandomMurdererController>().RNGMurder){
					SaveToTextScript.WriteStringLine(MurderStatement,0,"Statements/Statement" + i+".txt");
					if(GetComponent<RandomMurdererController>().RNGMurder ==6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i-1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder ==0){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder !=0 && GetComponent<RandomMurdererController>().RNGMurder !=6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
				}
			}
			break;
		case 2:
			MurderStatement = "he broke in... why did he kill them. I did not even get a good look at him he had a mask on. Am sorry i cant do this right now *cries*";
			WitnessStatement = "I heard gun shots but i never saw anyone leave";
			for(int i =1; i< 7;i++){
				SaveToTextScript.WriteStringLine( GetRandomNonHelpfulStatement(),0,"Statements/Statement" + i+".txt");
				if(i-1 == GetComponent<RandomMurdererController>().RNGMurder){
					SaveToTextScript.WriteStringLine(MurderStatement,0,"Statements/Statement" + i+".txt");
					Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
					if(GetComponent<RandomMurdererController>().RNGMurder ==6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i-1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder ==0){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder !=0 && GetComponent<RandomMurdererController>().RNGMurder !=6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
				}
			}
			break;
		case 3:
			MurderStatement = "I just got home and it was a mess, please tell me he ok";
			WitnessStatement = "I heard noise so i went to check and i saw a man leaving with something like a rolled up rug or carpet";
			for(int i =1; i< 7;i++){
				SaveToTextScript.WriteStringLine( GetRandomNonHelpfulStatement(),0,"Statements/Statement" + i+".txt");
				if(i-1 == GetComponent<RandomMurdererController>().RNGMurder){
					SaveToTextScript.WriteStringLine(MurderStatement,0,"Statements/Statement" + i+".txt");
					Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
					if(GetComponent<RandomMurdererController>().RNGMurder ==6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i-1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder ==0){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
					if(GetComponent<RandomMurdererController>().RNGMurder !=0 && GetComponent<RandomMurdererController>().RNGMurder !=6){
						SaveToTextScript.WriteStringLine(WitnessStatement,0,"Statements/Statement" + (i+1)+".txt");
					}
				}
			}
			break;
		}
	}

	string GetRandomNonHelpfulStatement(){

		switch (Random.Range (0, 11)) {
		case 0:
			return "Am sorry but i did not even know the people you're talking about";
			break;
		case 1:
			return "I was out that night with my girl";
			break;
		case 2:
			return "I was sleeping early that night due to work";
			break;
		case 3:
			return "I heard nothing but i had my headset on cause i was gaming all night";
			break;
		case 4:
			return "AM NOT SPEAKING WITHOUT A LAWER";
			break;
		case 5:
			return "I wish i could help but i dont know what you are talking about";
			break;
		case 6:
			return "All you cops do is get me in here when i've done nothing wrong";
			break;
		case 7:
			return "I did not kill anyone and if you had the evidence you would not be talking to me, would you!";
			break;
		case 8:
			return "Oh please why would i kill them, i hardly know them";
			break;
		case 9:
			return "please am innocent, i've never hurt anyone";
			break;
		case 10:
			return "Either arrest me or let me go already";
			break;
		default:
			return "Am sorry but i did not even know the people you're talking about";
			break;
		}
	}
}
