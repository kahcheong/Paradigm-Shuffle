using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeter : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 selfPos = gameObject.transform.position;
        selfPos.z = 0;

        Vector3 objectPos = player.transform.position;
        selfPos.x = selfPos.x - objectPos.x;
        selfPos.y = selfPos.y - objectPos.y;

        float angle = Mathf.Atan2(selfPos.y, selfPos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
    }
}
