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
        else if (wep.consume)
        {
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " + weapon.name +
                "@" + "Heal amount : " + wep.minDamage +
                "@" + "Stacks left :" + wep.stacks).Replace("@", "\n").Replace("(Clone)", "");
        }
        else if (wep.GODPOTION)
        {
            uses.GetComponent<Text>().text = ("LV " + wep.level + " " + weapon.name +
                   "@" + "Invincible for: " + wep.minDamage + "secs" +
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
        wep = weapon.GetComponent<Weapon>();
    }
    private void OnDisable()
    {
        if (gameObject.transform.childCount > 0) Destroy(gameObject.transform.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (yes)
        {
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
                else if (wep.consume)
                {
                    Player.player.hp += wep.minDamage;
                    wep.stacks--;
                }
                else if (wep.GODPOTION)
                {
                    StartCoroutine(GODMODE(wep.minDamage));
                }


                equip.equipment.change();
                inventory.inventor.change();
                Player.player.newEquip();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                yes = false;
                Destroy(uses);
                if (tinkerer.tinker != null) tinkerer.tinker.wep = wep;
                if (trader.traderer != null) trader.traderer.wep = wep;

                inventory.inventor.items[slot] = null;
                inventory.inventor.Reset();
                Player.player.newEquip();

            }

        }
        if (wep.stacks <= 0 && wep.consume)
        {
            Destroy(uses);
            yes = false;
            inventory.inventor.items[slot] = null;
            inventory.inventor.Reset();
            Player.player.newEquip();
        }
    }

    IEnumerator GODMODE(float time)
    {
        Player.player.GOD = true;
        yes = false;
        Destroy(uses);

        inventory.inventor.items[slot] = null;
        inventory.inventor.Reset();
        Player.player.newEquip();
        yield return new WaitForSeconds(time);
        Player.player.GOD = false;
        Player.player.newEquip();

        

    }
    
}
