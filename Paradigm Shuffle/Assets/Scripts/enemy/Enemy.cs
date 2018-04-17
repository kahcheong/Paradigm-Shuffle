using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour {

    private float height;
    public GameObject hpBar;

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
    public int bossCount;

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
        if (!boss)
        {
            GameObject other = Instantiate(hpBar, transform.position +  new Vector3(0, 2.5f/4, -0.1f), transform.rotation,transform);
            other.GetComponent<HP>().enem = gameObject;
        } else
        {
            GameObject other = Instantiate(hpBar, transform.position + new Vector3(0, 2.5f/2, -0.1f), transform.rotation, transform);
            other.GetComponent<HP>().enem = gameObject;
        }
        
    }

    private void OnEnable()
    {
        maxHp *= (FloorManager.floorManager.floor / 100 + 1.0f);
        minDamage *= (FloorManager.floorManager.floor / 100 + 1.0f);
        maxDamage *= (FloorManager.floorManager.floor / 100 + 1.0f);
        hp = maxHp;

    }

    // Update is called once per frame
    void Update () {

        height = GetComponent<BoxCollider>().bounds.size.y;
		
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

    private void OnDestroy()
    {
        Player.player.exp += exp;
        if (boss) GameController.control.elitesSlain++;
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
            var rotato = target.transform.rotation;
            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < atkSpeed; i++) { 
                GameObject other = Instantiate(weapon, transform.position, rotato);
                other.transform.parent = transform;
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
            if (bossCount == 1)
            {
                GameObject other = Instantiate(weapon, transform.position, target.transform.rotation);
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, target.transform.rotation * Quaternion.Euler(0, 0, 30));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, target.transform.rotation * Quaternion.Euler(0, 0, -30));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

            }
            else if (bossCount == 2)
            {
                var angle = target.transform.rotation;

                GameObject other = Instantiate(weapon, transform.position, angle);
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, 72));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, -72));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, 144));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, -144));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);
            }

            else if (bossCount == 3)
            {
                var angle = target.transform.rotation;

                GameObject other = Instantiate(weapon, transform.position, angle);
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, 60));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, -60));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, 120));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, -120));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

                other = Instantiate(weapon, transform.position, angle * Quaternion.Euler(0, 0, 180));
                other.GetComponent<slime>().damage = UnityEngine.Random.Range(minDamage, maxDamage);
                FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);
            }


            yield return new WaitForSeconds(1 / atkSpeed);
        }
        
        canAtk = true;
        canMove = true;

    }

    
}
