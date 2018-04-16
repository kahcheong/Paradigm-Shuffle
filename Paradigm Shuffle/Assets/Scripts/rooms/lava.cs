using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

    public float damage;
    public float ticksPerSecond;
    private bool canDamage;

    private void Start()
    {
        StartCoroutine(burn());
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "feet" && canDamage )
        {
            other.transform.parent.GetComponent<Player>().hp -= damage;
            //canDamage = false;
            
            
        }
        if (other.tag == "enemy" && canDamage)
        {
            other.GetComponent<Enemy>().hp -= damage;
            //canDamage = false;


        }

    }

    IEnumerator burn()
    {
        yield return new WaitForSeconds(1/ticksPerSecond);
        canDamage = true;
        yield return 0;
        canDamage = false;
        StartCoroutine(burn());
    }
}
