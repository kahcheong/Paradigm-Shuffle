using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string name;
    public float maxHp;
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

    public float damageReducFlat;
    public float damageReducPercent;

    public float distance;
    public GameObject player;
    public bool canAtk = true;
    public GameObject target;

    public GameObject weapon;

    private bool meleeAtk;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        maxHp = hp;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            Destroy(gameObject.gameObject);
        }
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (stab) {
            if (distance > 1.5f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                meleeAtk = false;
            }
            else if (canAtk && meleeAtk)
            {
                StartCoroutine(Atacking());
            }
            else
            {
                StartCoroutine(melee());
            }
        } 
        else if(canAtk)
        {
            StartCoroutine(Atacking());
        }
        

	}

    private IEnumerator Atacking()
    {
        canAtk = false;
        if (ranged)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
            other.GetComponent<Shoot>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
        }
        else if (stab)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation, transform);
            other.GetComponent<Stab>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
        } 
        else if (lob)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
            other.GetComponent<Lob>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
        }

        yield return new WaitForSeconds(1/atkSpeed);
        canAtk = true;
    }
    
    private IEnumerator melee()
    { 
        yield return new WaitForSeconds(2 / atkSpeed);
        meleeAtk = true;
    }
    
}
