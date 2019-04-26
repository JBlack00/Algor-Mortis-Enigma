using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool doTUT;
	public MurderManagerObj manager;
	public class MurderManagerObj{
		public TutLevelManager tutLevelMan;
		public SaveToText SavingText;
		public ReportController reportManager;
		public SceneController SceneMan;
		public inventory invo;


		public MurderManagerObj(){
			tutLevelMan = new TutLevelManager();
			SavingText = new SaveToText();
			reportManager = new ReportController();
			SceneMan = new SceneController();
			invo = new inventory();
				
		}
	}
	// Use this for initialization
	void Awake () {
       
		if (GameObject.Find ("MurderManager") == null) {
			//manager = new MurderManagerObj(); 
			GameObject MurderManager =new GameObject();

			MurderManager.AddComponent<SaveToText>();
			MurderManager.AddComponent<ReportController>();
			MurderManager.AddComponent<SceneController>();
			MurderManager.AddComponent<inventory>();
			MurderManager.AddComponent<soundHolder>();
			MurderManager.AddComponent<CreateFilesForSaving>();
			MurderManager.AddComponent<RandomMurdererController>();
            MurderManager.name = "MurderManager";
            if (doTUT)
            {
                AddLevelManager(0);
            }
            else {
                // AddLevelManager(Random.Range(1,3));
                AddLevelManager(1);
            }
           

           
		}

	}
	void AddLevelManager(int level)
    {
        GameObject MurderManager = GameObject.Find("MurderManager");
        switch (level)
        {
            
            case 0:
                MurderManager.AddComponent<TutLevelManager>();
                break;
            case 1:
                MurderManager.AddComponent<RickApartmentManager>();
                break;
            case 2:
                MurderManager.AddComponent<NewYorkApartmentManager>();
                break;
            default:
                MurderManager.AddComponent<TutLevelManager>();
                break;
        }
  
    }
    // Update is called once per frame
    void Update () {
		
	}
}
