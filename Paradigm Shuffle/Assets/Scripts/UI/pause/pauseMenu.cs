using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool canPause = false;
    public GameObject menu;
    public bool isPause = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        canPause = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canPause = false;
    }

	// Update is called once per frame
	void Update () {
		
        if (canPause && !isPause && Input.GetMouseButtonDown(0))
        {
            isPause = true;

        }

        if (isPause)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            Player.player.GOD = true;
            Player.player.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            Player.player.GOD = false;
            Player.player.enabled = true;  
        }

	}
}
