using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

    public float damage;
    public float ticksPerSecond;
    private bool canDamage = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && canDamage )
        {
            other.GetComponent<Player>().hp -= damage;
            canDamage = false;
            StartCoroutine(burn());
            
        }
    }

    IEnumerator burn()
    {
        yield return new WaitForSeconds(1/ticksPerSecond);
        canDamage = true;
    }
}
