using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp1 : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<RectTransform>().position = new Vector3 ( 12.9f, -141 *( 1- Player.player.hp/Player.player.maxHp) ,0);
	}
}
