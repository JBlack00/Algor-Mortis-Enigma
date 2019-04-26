using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtClueClose : MonoBehaviour {
	public string[] ItemsToLookAt;
	public GameObject CurrentObject;
	public GameObject player; 
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetCurrentClue(string obj){
		BringObjectToVeiw (obj);
	}
	public GameObject GetCurrentClue(){
		return CurrentObject;
	}
	public void BringObjectToVeiw(string obj){
		player.GetComponent<CharacterController> ().enabled = false;
		player.GetComponent<vp_FPInput> ().enabled = false;
		player.transform.GetChild(0).GetComponent<PlayerInteractions>().interactUI.SetActive(false);
		CurrentObject = player.transform.GetChild (0).GetChild (0).GetChild (GetArrayNumberFromString(obj)).gameObject;
		CurrentObject.SetActive (true);
	}
	public void StopLooking(){
		player.GetComponent<CharacterController> ().enabled = true;
		player.GetComponent<vp_FPInput> ().enabled = true;
		player.transform.GetChild(0).GetComponent<PlayerInteractions>().interactUI.SetActive(true);
		CurrentObject.SetActive (false);
	}
	int GetArrayNumberFromString(string newString){
		string temp= newString;
		
		for (int i=0; i<player.transform.GetChild (0).GetChild (0).childCount; i++) {
			if(player.transform.GetChild (0).GetChild (0).GetChild (i).gameObject.name == temp){
				return i;
			}
		}
		
		return 0;
	}
}
