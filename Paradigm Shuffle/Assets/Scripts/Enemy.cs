using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string name;
    public float hp;
    public int exp;

    public bool stab;
    public bool swipe;
    public bool lob;
    public bool ranged;
    public bool special;
    public bool notAgressive;
    public bool boss;

    public float minDamage;
    public float maxDamage;
    public int minRange;
    public int maxRange;
    public float atkSpeed;
    public float moveSpeed;

    public float distance;
    public GameObject player;

    public GameObject weapon;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            Destroy(gameObject.gameObject);
        }
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            hp--;
        }

    }
}
