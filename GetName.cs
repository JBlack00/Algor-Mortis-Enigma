using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetName : MonoBehaviour {
  //  public Collider coll;


    // Use this for initialization
    void Start () {
       // coll = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
			Debug.Log("working");
			if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("that is a "+ hit.collider.name);
            }
        }
    }
}
