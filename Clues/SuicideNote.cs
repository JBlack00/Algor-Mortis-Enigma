using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideNote : Clue {

	public SuicideNote(string NewName, int NewImportance, string note){
		string NoteString = note;
		SetName ("SuicideNote");
		SetImportance (1);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
