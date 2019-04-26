using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinventory : MonoBehaviour {
    public GameObject invoUI;
    public inventory inventory;
    // Use this for initialization
    void Start () {
        invoUI = GameObject.Find("UI Inventory");
        invoUI.SetActive(false);
        // inventory = 
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("i"))
        {

            if (invoUI.activeSelf) { 
           
              invoUI.SetActive(false);
            }
            else
            {
                invoUI.SetActive(true);
            }
        }
    }
    public  void RemoveObjectFromInvo(GameObject Object)
    {
        Debug.Log("WORKING SOME HOW");
        Destroy(Object);
       // inventory.invo.clueNames;
    }
}
