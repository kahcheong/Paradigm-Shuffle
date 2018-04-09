using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip : MonoBehaviour {

    public static equip equipment;

    public GameObject armor;
    public GameObject weapon;
    public GameObject trinket;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    // Use this for initialization
    void Start () {
        if (equipment == null)
        {
            equipment = this;
        }
        else if (equipment != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
