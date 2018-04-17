using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour {

    private float size;


	
	// Update is called once per frame
	void Update () {

        size = Player.player.exp;
        if (size > 100) size = 100;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(size/100f, size/100f, 0);

	}
}
