using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    private float maxHp;
    private float curHp;
    private float maxX;
    public Enemy en;

    public GameObject enem;
    public GameObject bar;

	// Use this for initialization
	void Start () {
        en = enem.GetComponent<Enemy>();
        maxHp = en.maxHp;
        maxX = transform.localScale.x;


	}

    private void Update()
    {
        curHp = en.hp;
        transform.localScale =  new Vector3(maxX * curHp / maxHp, transform.localScale.y, transform.localScale.z);
    }
}
