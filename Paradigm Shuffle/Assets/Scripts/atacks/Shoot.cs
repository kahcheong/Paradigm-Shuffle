using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed;
    public float damage;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime*speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" && tag == "playerAttack" )
        {
            float temp = damage - other.GetComponent<Enemy>().damageReducFlat;
            if (temp > 0) other.GetComponent<Enemy>().hp -= temp * (1f-other.GetComponent<Enemy>().damageReducPercent);
            
            Destroy(gameObject.gameObject);
        }
        if (other.tag == "Player" && tag == "weapon")
        {
            float temp = damage - other.GetComponent<Player>().damageReducFlat;
            if (temp > 0) other.GetComponent<Player>().hp -= temp * (1f - other.GetComponent<Player>().damageReducPercent);
            Destroy(gameObject.gameObject);
        }
        if (other.tag == "wall")
        {
            Destroy(gameObject.gameObject);
        }
    }
}
  