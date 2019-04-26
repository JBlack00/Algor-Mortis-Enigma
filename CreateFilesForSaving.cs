using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq; 

public class CreateFilesForSaving : MonoBehaviour {
	public string[] paths = new string[14];
	public string[] Dir = new string[2];
	public SaveToText saveScript;
	// Use this for initialization
	void Awake () {
		saveScript = this.gameObject.GetComponent<SaveToText> ();
		Dir [0] = Application.dataPath + "/Resources/";
		Dir [1] = Application.dataPath + "/Resources/Statements/";

		paths[0] = Application.dataPath + "/Resources/GameStatus.txt";
		paths[1] = Application.dataPath + "/Resources/PlayerManager.txt";
		for (int i =1; i< 7; i++) {
			paths [1+ i] = Application.dataPath + "/Resources/ReportTemplate" + i+".txt";
		}
		for (int i =1; i< 7; i++) {
			paths [7+ i] = Application.dataPath + "/Resources/Statements/Statement" + i+".txt";
		}

		CheckAllFiles ();
		////remove if you need customs till require a full redub on all reports 
		ResetDefults ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ResetDefults(){
		for (int i =0; i< paths.Length; i++) {
			SetFileInfo (i);
		}
	}
	void CheckAllFiles(){
		for (int p =0; p< Dir.Length; p++) {
			if (!Directory.Exists (Dir [p])) {
				Directory.CreateDirectory (Dir [p]);
			}
		}
		for (int i =0; i< paths.Length; i++) {
			if(!File.Exists(paths[i])){
				File.WriteAllText(paths[i], "");
				SetFileInfo(i);
				Debug.Log("number is " + i);
			}
		}
	}
	void SetFileInfo(int fileNumber){
		switch(fileNumber){
		case 0:
			saveScript.WriteStringLine("New",0,"GameStatus.txt");
			saveScript.WriteStringLine("NoClue",1,"GameStatus.txt");
			break;
		case 1:
			saveScript.WriteStringLine("TUTDone",0,"PlayerManager.txt");
			break;
		case 2:
			saveScript.WriteStringLine("Cecil Milne",0,"ReportTemplate1.txt");
			saveScript.WriteStringLine("Cec-wan-sos",1,"ReportTemplate1.txt");
			saveScript.WriteStringLine("May. 28th 1993",2,"ReportTemplate1.txt");
			saveScript.WriteStringLine("6ft 3”",3,"ReportTemplate1.txt");
			saveScript.WriteStringLine("14st",4,"ReportTemplate1.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate1.txt");
			saveScript.WriteStringLine("Years ago, he lost his home when it was destroyed after a food shortage and subsequent riot. He had to fight to survive, we are unable to ascertain what he did during this time. However, what we do know is his business protocol, after surviving against odds Cecil owner of Cec-Wan-Sos Ltd. has taken brutal steps to wipe clean the market and all who oppose his company. Illicit dealings, blackmail, and murder are among the things we are trying to prove he is responsible of. His is highly dangerous and wealth, ensure you are making the right choice before attempting to peruse.",6,"ReportTemplate1.txt");
			break;
		case 3:
			saveScript.WriteStringLine("Craig Barkley",0,"ReportTemplate2.txt");
			saveScript.WriteStringLine("Barks",1,"ReportTemplate2.txt");
			saveScript.WriteStringLine("Apr. 17th 1991",2,"ReportTemplate2.txt");
			saveScript.WriteStringLine("6ft",3,"ReportTemplate2.txt");
			saveScript.WriteStringLine("8st",4,"ReportTemplate2.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate2.txt");
			saveScript.WriteStringLine("This guy just loves knives. A self-proclaimed “edgy goth” with cringey hashtags in all “...A lust for blood tonight lol #make’embleed”. He had several charges but mainly seems like an attention seeker more than an actual threat to society.He has however been seen with and charged with carrying knives on multiple occasions and has had an investigation lead into them due to buying a surplus of dangerous items these include incredibly dangerous knives and fire arms, although every gun confiscated so far has been a Ball Baring firing gun much to the precinct’s embarrassment.",6,"ReportTemplate2.txt");
			break;
		case 4:
			saveScript.WriteStringLine("Fred Thunder",0,"ReportTemplate3.txt");
			saveScript.WriteStringLine("Stormer",1,"ReportTemplate3.txt");
			saveScript.WriteStringLine("Mar. 22th 1989",2,"ReportTemplate3.txt");
			saveScript.WriteStringLine("6ft 1”",3,"ReportTemplate3.txt");
			saveScript.WriteStringLine("13st",4,"ReportTemplate3.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate3.txt");
			saveScript.WriteStringLine("He accidently maimed somebody during an invasion and was initiated in a gang. After a while in the gang he got used to violence. He helped work undercover for us for 4 years before going dark. We have heard he is nearby and has started acting out in violence just like before working with us. He is highly capable and a high threat.",6,"ReportTemplate3.txt");
			break;
		case 5:
			saveScript.WriteStringLine("Keaton Begum",0,"ReportTemplate4.txt");
			saveScript.WriteStringLine("Keablood",1,"ReportTemplate4.txt");
			saveScript.WriteStringLine("Dec. 04 1977",2,"ReportTemplate4.txt");
			saveScript.WriteStringLine("5ft 11”",3,"ReportTemplate4.txt");
			saveScript.WriteStringLine("12st",4,"ReportTemplate4.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate4.txt");
			saveScript.WriteStringLine("Keaton Begum is a pro baseball player known as Keablood for his tendency to start brutal fights whilst playing. He has the ability to hit a ball at 330 MPH, that’s a swing capable of almost taking any victims head almost off their shoulders. He has a violent past with multiple assaults on record however after getting into the major leagues the list of crimes end, we suspect they are paying for them to be covered up instead of Keaton turning into a good citizen.",6,"ReportTemplate4.txt");
			break;
		case 6:
			saveScript.WriteStringLine("Rocky Paine",0,"ReportTemplate5.txt");
			saveScript.WriteStringLine("Petram Paine",1,"ReportTemplate5.txt");
			saveScript.WriteStringLine("Sep. 17th 1988",2,"ReportTemplate5.txt");
			saveScript.WriteStringLine("6ft 1”",3,"ReportTemplate5.txt");
			saveScript.WriteStringLine("14st",4,"ReportTemplate5.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate5.txt");
			saveScript.WriteStringLine("Rocky Paine is the husband of the Victim, he has a clean record and neighbours seem to genuinely like him. Though looking through his ISP history we have found some suspicious searches for how to preform certain surgeries and the purchase of expert sharp cooking knives when his wife does all the cooking. As is normal all close relatives at the scene of the crime when police appear are considered prime suspects.",6,"ReportTemplate5.txt");
			break;
		case 7:
			saveScript.WriteStringLine("Rowan Fischer",0,"ReportTemplate6.txt");
			saveScript.WriteStringLine("The Fischer",1,"ReportTemplate6.txt");
			saveScript.WriteStringLine("Jan. 7th 1982",2,"ReportTemplate6.txt");
			saveScript.WriteStringLine("6ft 4”",3,"ReportTemplate6.txt");
			saveScript.WriteStringLine("7st",4,"ReportTemplate6.txt");
			saveScript.WriteStringLine("Male",5,"ReportTemplate6.txt");
			saveScript.WriteStringLine("Rowan was employed for a time as a Military Officer Special and Tactical Operations Leader for 5 years before quitting due to stress and pressure from new higher ups. He has a clean record and doesn’t seem to be a threat according to the character references we have acquired. However, he was spotted near the crime scene at the same time as the murder and with the type of job title he used to have we need to treat him as a suspect.",6,"ReportTemplate6.txt");
			break;
		case 8:
			saveScript.WriteStringLine("Test number 1",0,"Statements/Statement1.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement1.txt");
			break;
		case 9:
			saveScript.WriteStringLine("Test number 2",0,"Statements/Statement2.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement2.txt");
			break;
		case 10:
			saveScript.WriteStringLine("Test number 3",0,"Statements/Statement3.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement3.txt");
			break;
		case 11:
			saveScript.WriteStringLine("Test number 4",0,"Statements/Statement4.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement4.txt");
			break;
		case 12:
			saveScript.WriteStringLine("Test number 5",0,"Statements/Statement5.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement5.txt");
			break;
		case 13:
			saveScript.WriteStringLine("Test number 6",0,"Statements/Statement6.txt");
			saveScript.WriteStringLine("NoStatement",1,"Statements/Statement6.txt");
			break;
		}
	}
}
