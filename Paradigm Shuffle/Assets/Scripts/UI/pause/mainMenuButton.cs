using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuButton : MonoBehaviour {

    public GameObject returner;

	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => TaskOnClick());
    }

    private void TaskOnClick()
    {
        Player.player.hp = -Player.player.maxHp;
        returner.GetComponent<pauseMenu>().isPause = false;
    }
}
