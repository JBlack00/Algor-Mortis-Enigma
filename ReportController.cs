using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		//Debug.Log (gameObject.GetComponent<SaveToText> ().ReadString ("ReportTest.txt")[0]);

	}
	
	// Update is called once per frame
	void Update () {

	}
	string GetRandomReport(){
		return " john \n john \n 18 \n male \n 6ft \n12st ";
	}
}
