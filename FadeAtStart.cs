using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAtStart : MonoBehaviour {
    public GameObject FadeImage;
    public float TransitionSpeed;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        FadeNow();
    }

    void FadeNow()
    {
        float alpha = FadeImage.GetComponent<Image>().color.a;
        if (alpha > 0)
        {
            alpha -= TransitionSpeed * Time.deltaTime;
            Debug.Log (alpha);
            Color newColor = new Color(0, 0, 0, alpha);
            FadeImage.GetComponent<Image>().color = newColor;

        }
    }
}
