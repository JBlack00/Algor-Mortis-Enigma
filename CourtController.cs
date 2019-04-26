using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourtController : MonoBehaviour {
    public string SuspectName;
    public Image backgroundPicture;
    public Text SuspectNameText;
    public Text VerdictText;
    public Text Reason;
	// Use this for initialization
	void Start () {
        SuspectNameText.text = SuspectName + " has been found... ";
        GetReason(false, 0);
        }
	
	// Update is called once per frame
	void Update () {
		
	}
    void GetReason(bool Type, int ReasonNumber)
    {
        if (Type)
        {
            switch (ReasonNumber)
            {
                case 0:

                    break;
                default:
                    break;
            }
           Color TempColor = new Color(170f/255f, 246 / 255f, 255 / 255f);
            backgroundPicture.color = TempColor;
        }
        else
        {
            switch (ReasonNumber)
            {
                case 0:

                    break;
                default:
                    break;
            }
            Color TempColor = new Color(255f / 255f, 183f / 255f, 170f / 255f);
            backgroundPicture.color = TempColor;
        }
    }
}
//reason number 0: not enough evidence to convict 
//reason number 1: jury was ageinst you 