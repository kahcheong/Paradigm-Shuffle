using System;
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
    public bool canAtk = true;
    public GameObject target;

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


        if (distance > 1.5)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        else if(canAtk)
        {
            StartCoroutine(Atacking());
        }

	}

    private IEnumerator Atacking()
    {
        Vector3 playerPos = player.transform.position;

        Vector3 objectPos = player.transform.position;
        playerPos.x = playerPos.x - objectPos.x;
        playerPos.y = playerPos.y - objectPos.y;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;

        canAtk = false;
        GameObject atk =  Instantiate(weapon, gameObject.transform);
        atk.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        yield return new WaitForSeconds(1/atkSpeed);
        canAtk = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            hp--;
        }

    }

    
}
