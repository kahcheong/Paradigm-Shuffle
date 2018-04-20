using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floorDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Floor : " + FloorManager.floorManager.floor;
        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.Q)) FloorManager.floorManager.floor++;
    }
}
