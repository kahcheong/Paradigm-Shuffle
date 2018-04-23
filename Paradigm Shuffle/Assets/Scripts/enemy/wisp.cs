using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wisp : MonoBehaviour {

    private bool booom = false;
    private float damage;

	// Use this for initialization
	void OnEnable () {
        damage = gameObject.GetComponent<Enemy>().maxDamage * 5;
        StartCoroutine(boom());
	}
	
	IEnumerator boom()
    {
        yield return new WaitForSeconds(5);
        transform.localScale = transform.localScale * 3;
        booom = true;
        yield return 0;
        booom = false;
        yield return new WaitForSeconds(0.1F);
        Destroy(gameObject.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && booom)
        {
            other.GetComponent<Player>().hp -= damage;
        }
    }
}
