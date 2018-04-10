using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class takenItems : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject weapon;
    private Weapon wep;
    public GameObject desc;
    private GameObject uses;
    private bool yes;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uses = Instantiate(desc, transform);
        yes = true;
        if (wep.weapon)
        {
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " +   weapon.name  + 
                "@" + "Damage : " + wep.minDamage + " - " + wep.maxDamage + 
                "@" + "Attack speed : " + wep.atkSpeed + "/s").Replace("@", "\n").Replace("(Clone)", "");
        } 
        else if (wep.flatReduc)
        {
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " + weapon.name +
                "@" + "reduces incoming damage by : " + wep.flatReduction +
                "@").Replace("@", "\n").Replace("(Clone)", "");
        }
        else if (wep.percentReduc)
        {
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " + weapon.name +
                "@" + "increases HP by : " + (wep.percentReduction-1)*100 + "%" +
                "@").Replace("@", "\n").Replace("(Clone)", "");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        yes = false;
        Destroy(uses);
    }

    // Use this for initialization
    void OnEnable () {
        wep = weapon.GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0) && yes)
        {
            if (wep.weapon)
            {

            }
            else if (wep.trinket)
            {

            }
            else if (wep.percentReduc)
            {

            }
        }

	}
}
