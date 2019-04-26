using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {
	public InvestigationInvontory invo;
   
	[System.Serializable]
	public class InvestigationInvontory{
		public List<string> clueNames; 
		public InvestigationInvontory(){
			clueNames = new List<string>{};
		}
	}
    // Use this for initialization
    void Start()
    {
        invo = new InvestigationInvontory();
      
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
