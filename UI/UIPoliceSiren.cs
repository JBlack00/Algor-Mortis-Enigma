using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoliceSiren : MonoBehaviour {
    public Color newColour;
    public Image ImageToChange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ImageToChange.material.color = Color.white;
        float lerp = Mathf.PingPong(Time.time, 1f) / 1f;
        ImageToChange.color = Color.Lerp(Color.red, Color.blue, lerp);
    }
}
