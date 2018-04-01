using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {

    public GameObject atk;

    private void Awake()
    {
        StartCoroutine(Atk());
    }



    IEnumerator Atk()
    {
        atk.GetComponent<Animator>().Play("stab");
        Debug.Log("attaking stab");
        yield return new WaitForSeconds(0.09F);
        Destroy(gameObject.gameObject);
    }
}
