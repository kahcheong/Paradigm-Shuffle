using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizrd : MonoBehaviour {


    public Enemy me;

    private float min;
    private float max;

    private void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update () {
        if (max > 0)  me.maxDamage = max * (me.distance / 13.5f);

	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        max = me.maxDamage;
    }
}
