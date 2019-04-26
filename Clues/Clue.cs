using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clue : MonoBehaviour {
    private string name;
    private int importance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetName(string newName){ name = newName; }
    public void SetImportance(int newImportance) { importance = newImportance; }

    public string GetName(){ return name;}
    public int GetImportance() { return importance; }
}
