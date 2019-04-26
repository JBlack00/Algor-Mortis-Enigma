using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomMurdererController : MonoBehaviour {
	public string Murderer;
	public List<string> PossibleMurderers = new List<string>();
	public int RNGMurder;
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene ().name == "DetectiveOffice") {
			//Invoke ("waitTillLoaded", 1f);
			waitTillLoaded();
			Debug.Log ("Invoking " + SceneManager.GetActiveScene ().name);
		}
	}
	void waitTillLoaded(){
		if (GameObject.Find ("MurderManager").GetComponent<SaveToText> ().ReadStringLine ("GameStatus.txt", 0) == "New") {
			SetRandomMurderForTut ();
			Debug.Log ("reading that stupid string " + GameObject.Find ("MurderManager").GetComponent<SaveToText> ().ReadStringLine ("GameStatus.txt", 0));

			GameObject.Find ("MurderManager").GetComponent<SaveToText> ().WriteStringLine("in progress",0, "GameStatus.txt");
		}

	}
	// Update is called once per frame
	void Update () {
		
        
	}
	public void SetRandomMurderForTut(){
		OfficeNavController tempOFF = GameObject.Find("LaptopScreen").GetComponent<OfficeNavController>();
		RNGMurder = Random.Range (0,  tempOFF.Reports.Count);

		for (int i=0; i <  tempOFF.Reports.Count; i++) {

			if(RNGMurder == i){
			Murderer = tempOFF.Reports[i].name;
			PossibleMurderers.Add(Murderer);
			}else{
				Debug.Log ("current test " +  tempOFF.Reports[i].name);
				PossibleMurderers.Add( tempOFF.Reports[i].name);
			}
		}


	}
}
