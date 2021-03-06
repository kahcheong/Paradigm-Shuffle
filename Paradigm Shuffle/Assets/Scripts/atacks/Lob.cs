﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lob : MonoBehaviour {

    public float speed;
    public float damage;
    private bool canBoom = true;
    private GameObject room;

    private void OnEnable()
    {
        room = FloorManager.floorManager.currRoom;   
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
        if (room != FloorManager.floorManager.currRoom) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "enemy" && tag == "playerAttack" && other.GetComponent<Enemy>().enabled)
        {
            float temp = damage - other.GetComponent<Enemy>().damageReducFlat;
            if (temp > 0) other.GetComponent<Enemy>().hp -= temp * (1f - other.GetComponent<Enemy>().damageReducPercent);

            if (canBoom)
            {
                canBoom = false;
                StartCoroutine(boom());
            }
        }
        if (other.tag == "Player" && tag == "weapon")
        {
            float temp = damage - other.GetComponent<Player>().damageReducFlat;
            other.GetComponent<Player>().hp -= temp;

            if (canBoom)
            {
                canBoom = false;
                StartCoroutine(boom());
            }
        }
        if (other.tag == "wall")
        {
            if (canBoom)
            {
                canBoom = false;
                StartCoroutine(boom());
            }
        }
    }

    IEnumerator boom()
    {
        transform.localScale = transform.localScale * 3;
        yield return new WaitForSeconds(0.05F);
        Destroy(gameObject.gameObject);
    }
}
