﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    public GameObject atk;
    public float damage;

    private void Awake()
    {
        atk.GetComponent<Animator>().Play("stab");
        StartCoroutine(Atk());
    }



    IEnumerator Atk()
    {
        yield return new WaitForSeconds(0.09F);
        Destroy(gameObject.gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && tag == "playerAttack")
        {
            float temp = damage - other.GetComponent<Enemy>().damageReducFlat;
            if (temp > 0) other.GetComponent<Enemy>().hp -= temp * (1f - other.GetComponent<Enemy>().damageReducPercent);

        }
        if (other.tag == "Player" && tag == "weapon")
        {
            float temp = damage - other.GetComponent<Player>().damageReducFlat;
            if (temp > 0) other.GetComponent<Player>().hp -= temp * (1f - other.GetComponent<Player>().damageReducPercent);
        }
    }
}
