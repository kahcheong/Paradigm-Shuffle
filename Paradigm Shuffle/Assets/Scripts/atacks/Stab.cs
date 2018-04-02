using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    public GameObject atk;

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


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy" && tag == "playerAttack")
        {
            other.GetComponent<Enemy>().hp--;
            Destroy(gameObject.gameObject);
        }
        if (other.tag == "Player" && tag == "weapon")
        {
            other.GetComponent<Player>().hp--;
            Destroy(gameObject.gameObject);
        }
    }
}
