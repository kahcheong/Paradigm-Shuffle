using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour {

    private float size;
    public GameObject hint;
    public bool lvlUp;

    public GameObject hpUp;
    public GameObject dmgUp;

	
	// Update is called once per frame
	void Update () {

        size = Player.player.exp;
        if (size > 100) size = 100;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(size/100f, size/100f, 0);

        if (size == 100) hint.SetActive(true);
        else hint.SetActive(false);

        if (Input.GetKeyDown(KeyCode.O) && Player.player.exp >=100)
        {
            lvlUp = true;
        }
        if (lvlUp)
        {
            hpUp.SetActive(true);
            dmgUp.SetActive(true);
        }
        else
        {
            hpUp.SetActive(false);
            dmgUp.SetActive(false);
        }

    }
}
