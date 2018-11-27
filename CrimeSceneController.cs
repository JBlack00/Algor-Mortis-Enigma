using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeSceneController : MonoBehaviour {
	public GameObject[] Scenarios;
	public GameObject SceneManager;
	// Use this for initialization
	void Start () {
		Scenarios = GameObject.FindGameObjectsWithTag ("Scenarios");
		SceneManager = GameObject.Find ("MurderManager");
		checkScene ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void checkScene(){
		TutLevelManager tutMan =SceneManager.GetComponent<TutLevelManager> ();
		if (tutMan.thisMurder == tutMan.PossibleMurders[0])
		{
			Scenarios[3].SetActive(true);
			Scenarios[1].SetActive(false);
			Scenarios[2].SetActive(false);
			Scenarios[0].SetActive(false);

			Debug.Log(Scenarios[0].name);
		}
		else if (tutMan.thisMurder == tutMan.PossibleMurders[1])
		{
			Scenarios[1].SetActive(true);
			Scenarios[0].SetActive(false);
			Scenarios[2].SetActive(false);
			Scenarios[3].SetActive(false);
			Debug.Log(Scenarios[1].name);
		}
		else if (tutMan.thisMurder == tutMan.PossibleMurders[2])
		{
			Scenarios[2].SetActive(true);
			Scenarios[1].SetActive(false);
			Scenarios[0].SetActive(false);
			Scenarios[3].SetActive(false);
			Debug.Log(Scenarios[2].name);
		}
		else if (tutMan.thisMurder == tutMan.PossibleMurders[3])
		{	Scenarios[0].SetActive(true);
			Scenarios[1].SetActive(false);
			Scenarios[2].SetActive(false);
			Scenarios[3].SetActive(false);

			Debug.Log(Scenarios[3].name);
		}
	}

}
