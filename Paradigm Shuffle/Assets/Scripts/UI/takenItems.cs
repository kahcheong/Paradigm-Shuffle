﻿using System;
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
    public int slot;

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
    private void OnDisable()
    {
        if (gameObject.transform.childCount >0) Destroy(gameObject.transform.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update () {

		if (yes) {
            if (Input.GetMouseButtonDown(0))
            {
                yes = false;
                Destroy(uses);
                if (wep.weapon)
                {
                    if (equip.equipment.weaponObject == null)
                    {
                        equip.equipment.weaponObject = weapon;
                        inventory.inventor.items[slot] = null;
                        inventory.inventor.Reset();
                    }
                    else
                    {
                        GameObject temp = equip.equipment.weaponObject;

                        equip.equipment.weaponObject = weapon;
                        inventory.inventor.items[slot] = temp;
                    }
                }
                else if (wep.trinket)
                {
                    if (equip.equipment.trinketObject == null)
                    {
                        equip.equipment.trinketObject = weapon;
                        inventory.inventor.items[slot] = null;
                        inventory.inventor.Reset();
                    }
                    else
                    {
                        GameObject temp = equip.equipment.trinketObject;

                        equip.equipment.trinketObject = weapon;
                        inventory.inventor.items[slot] = temp;
                    }
                }
                else if (wep.percentReduc || wep.flatReduc)
                {
                    if (equip.equipment.armorObject == null)
                    {
                        equip.equipment.armorObject = weapon;
                        inventory.inventor.items[slot] = null;
                        inventory.inventor.Reset();

                    }
                    else
                    {
                        GameObject temp = equip.equipment.armorObject;

                        equip.equipment.armorObject = weapon;
                        inventory.inventor.items[slot] = temp;
                    }
                }
                equip.equipment.change();
                inventory.inventor.change();
                Player.player.newEquip();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                yes = false;
                Destroy(uses);

                inventory.inventor.items[slot] = null;
                inventory.inventor.Reset();
                Player.player.newEquip();

            }

        }

	}
}
