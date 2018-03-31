using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public int id;
    public string Name;
    public GameObject enemy;
    // minions to spawn for special enemies
    
    public bool spawnsMinion;
    public GameObject minion;

    public int minionCount; //how many at a time
    public int minionFrequency; // how long between spawns in seconds
    //spaces in room to spawn
    public int minInstance;
    public int maxInstance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
