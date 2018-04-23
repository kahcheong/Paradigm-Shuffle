using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "feet")
        {
            other.transform.parent.GetComponent<Player>().hp += other.transform.parent.GetComponent<Player>().maxHp / 2f;
            Destroy(transform.parent.gameObject);
        }
    }
}
