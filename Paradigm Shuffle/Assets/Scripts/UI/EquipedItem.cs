using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipedItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " + weapon.name +
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
                "@" + "increases HP by : " + (((int)((wep.percentReduction - 1) * 1000)) / 10f).ToString() + "%" +
                "@").Replace("@", "\n").Replace("(Clone)", "");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        yes = false;
        Destroy(uses);
    }

    // Use this for initialization
    void OnEnable()
    {
        if (weapon!= null) wep = weapon.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (yes)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inventory.inventor.stored < 4)
                {
                    yes = false;
                    Destroy(uses);

                    inventory.inventor.items[inventory.inventor.stored] = weapon;
                    inventory.inventor.stored++;
                    inventory.inventor.change();
                    if (slot == 0) equip.equipment.weaponObject = null;
                    if (slot == 1) equip.equipment.armorObject = null;
                    if (slot == 2) equip.equipment.trinketObject = null;
                    equip.equipment.change();
                    Player.player.newEquip();

                }
                else
                {
                    uses.GetComponent<Text>().text = "Inventory too full to unequip";
                    Player.player.newEquip();
                }
            }


        }

    }
}
