using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject atk;
    public float speed;


    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime*speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && tag == "playerAttack" )
        {
            other.GetComponent<Enemy>().hp--;
            Destroy(gameObject.gameObject);
        }
        if (other.tag == "Player" && tag == "weapon")
        {
            Destroy(gameObject.gameObject);
        }
        if (other.tag == "wall")
        {
            Destroy(gameObject.gameObject);
        }
    }
}
  