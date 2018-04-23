using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    public float speed;
    public float damage;
    public Enemy awake;



    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && tag == "weapon")
        {
            float temp = damage - other.GetComponent<Player>().damageReducFlat;
            if (temp > 0) other.GetComponent<Player>().hp -= temp * (1f - other.GetComponent<Player>().damageReducPercent);
            awake.enabled = true;
            transform.localRotation = Quaternion.Euler(90, 0, 0);
            tag = "enemy";
            enabled = false;
        }
        if (other.tag == "wall" || other.tag == "playerAttack")
        {
            awake.enabled = true;
            transform.localRotation = Quaternion.Euler(90, 0, 0);
            tag = "enemy";
            enabled = false;
        }

    }

}
