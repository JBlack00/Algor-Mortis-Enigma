using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
    public bool UseYaixs;
    public bool UseXaixs;
    public bool UseZaixs;

    public float XRotateSpeed;
    public float YRotateSpeed;
    public float ZRotateSpeed;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (UseXaixs)
        {
            this.gameObject.transform.Rotate(XRotateSpeed * Time.deltaTime,0,0);
        }
        if (UseYaixs)
        {
            this.gameObject.transform.Rotate(0, YRotateSpeed * Time.deltaTime, 0, Space.World);
        }
        if (UseZaixs)
        {
            this.gameObject.transform.Rotate(0, 0, ZRotateSpeed * Time.deltaTime);
        }
    }
}
