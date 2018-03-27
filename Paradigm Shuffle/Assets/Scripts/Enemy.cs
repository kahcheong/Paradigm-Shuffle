using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string name;
    public int hp;
    public int exp;

    public bool stab;
    public bool swipe;
    public bool lob;
    public bool ranged;
    public bool boss;
    public int damage;
    public int range;
    public float atkSpeed;
    public int moveSpeed;

    public GameObject weapon;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
