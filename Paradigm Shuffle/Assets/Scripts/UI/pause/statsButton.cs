using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class statsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject text;
    private FollowMouse atk;
    private Player player;

    private void OnEnable()
    {
        player = Player.player;
        atk = player.gameObject.transform.GetChild(0).GetComponent<FollowMouse>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
        text.GetComponent<Text>().text = (  "Minimum Damage: " + atk.minDamage + "@" + 
                                            "Maximum Damage: " + atk.maxDamage + "@" + 
                                            "Attack Speed: " + atk.atkSpeed + " attacks per second" + "@" +
                                            "Max HP: " + (int)player.maxHp + "@" + 
                                            "Flat Damage Reduction: " + player.damageReducFlat + "@" +
                                            "EXP: " + player.exp + "@" +
                                            "HP LVL: " + player.hpLvl + "@" +
                                            "Damage LVL: " + player.damageLvl + "@"
                                            ).Replace("@", "\n");
	}
}
