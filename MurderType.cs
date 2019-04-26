using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MurderType : Clue {

   public MurderType(string newName, int newImportance){
        SetName( newName);
        SetImportance(newImportance);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
