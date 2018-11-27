using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {
	public GameObject FadeImage;
	public bool TimeToFade;
	// Use this for initialization
	void Start () {
		FadeImage = gameObject.transform.GetChild (0).gameObject;
		FadeImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeToFade) {
			FadeNow ();
		}
	}
	public void SetTimeToFade(bool newTimeToFade){
		TimeToFade = newTimeToFade;
	}
	public bool GetTimeToFade(){
		return TimeToFade;
	}
	void FadeNow(){
		float alpha = FadeImage.GetComponent<Image> ().color.a;
		if(alpha < 1) {		
			alpha +=  0.5f *Time.deltaTime;
			//Debug.Log (alpha);
			Color newColor = new Color(0, 0, 0, alpha);
			FadeImage.GetComponent<Image> ().color = newColor;
			
		}
	}
}
