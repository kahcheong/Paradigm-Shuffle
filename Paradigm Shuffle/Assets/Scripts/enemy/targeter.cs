using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeter : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 selfPos = gameObject.transform.position;
        selfPos.z = -0.1f;

        Vector3 objectPos = player.transform.position;
        selfPos.x = selfPos.x - objectPos.x;
        selfPos.y = selfPos.y - objectPos.y;

        float angle = Mathf.Atan2(selfPos.y, selfPos.x) * Mathf.Rad2Deg;
        if (enemy.GetComponent<Enemy>().stab) transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle+180));
        if (enemy.GetComponent<Enemy>().ranged) transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        if (enemy.GetComponent<Enemy>().lob) transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        if (enemy.GetComponent<Enemy>().boss) transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }
}
