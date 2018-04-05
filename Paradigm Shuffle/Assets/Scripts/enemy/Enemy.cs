using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
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
    public float minRange;
    public float maxRange;
    public float atkSpeed;
    public float moveSpeed;
    private bool canMove = true;

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
            if (distance > minRange + 0.4f)
            {
                if (canMove)
                {
                    float step = moveSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                }
                
            }
            else if (canAtk)
            {
                StartCoroutine(Atacking());
            }


            
        } 
        else if(canAtk )
        {
            StartCoroutine(Atacking());
        }


        

	}

    public IEnumerator Atacking()
    {
        canAtk = false;
        meleeAtk = false;
        if (ranged)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
            if (minDamage != maxDamage) other.GetComponent<Shoot>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
            else other.GetComponent<Shoot>().damage = maxDamage;
            yield return new WaitForSeconds(1 / atkSpeed);
        }
        else if (stab)
        {
            canMove = false;
            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < atkSpeed; i++) { 
                GameObject other = Instantiate(weapon, transform.position, target.transform.rotation, transform);
                other.GetComponent<Stab>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                if (i<atkSpeed-1) yield return new WaitForSeconds(1 / atkSpeed);
            }
            canMove = true;
        } 
        else if (lob)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
            other.GetComponent<Lob>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
            yield return new WaitForSeconds(1 / atkSpeed);
        }
        else if (boss)
        {
            GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
            other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);

            other = Instantiate(weapon, transform.position, target.transform.rotation * Quaternion.Euler(0,0,30));
            other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);

            other = Instantiate(weapon, transform.position, target.transform.rotation * Quaternion.Euler(0, 0, -30));
            other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);

            yield return new WaitForSeconds(1 / atkSpeed);
        }
        
        canAtk = true;
        canMove = true;

    }

    
}
