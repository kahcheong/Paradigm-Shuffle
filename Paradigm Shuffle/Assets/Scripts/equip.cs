using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equip : MonoBehaviour {

    public static equip equipment;

    public GameObject armorSlot;
    public GameObject weaponSlot;
    public GameObject trinketSlot;

    public GameObject armorObject;
    public GameObject weaponObject;
    public GameObject trinketObject;

    // Use this for initialization
    void Start () {
        if (equipment == null)
        {
            equipment = this;
        }
        else if (equipment != this)
        {
            Destroy(gameObject);
        }

        change();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void change()
    {
        if (armorObject != null)
        {
            armorSlot.GetComponent<Image>().enabled = true;
            armorSlot.GetComponent<Image>().preserveAspect = true;
            armorSlot.GetComponent<Image>().sprite = armorObject.GetComponent<SpriteRenderer>().sprite;
            armorSlot.GetComponent<EquipedItem>().weapon = armorObject;
            armorSlot.GetComponent<EquipedItem>().enabled = false;
            armorSlot.GetComponent<EquipedItem>().enabled = true;
        }
        else
        {
            armorSlot.GetComponent<EquipedItem>().weapon =null; 
            armorSlot.GetComponent<Image>().enabled = false;
            armorSlot.GetComponent<EquipedItem>().enabled = false;
        }

        if (weaponObject != null)
        {
            weaponSlot.GetComponent<Image>().enabled = true;
            weaponSlot.GetComponent<Image>().preserveAspect = true;
            weaponSlot.GetComponent<Image>().sprite = weaponObject.GetComponent<SpriteRenderer>().sprite;
            weaponSlot.GetComponent<EquipedItem>().weapon = weaponObject;
            weaponSlot.GetComponent<EquipedItem>().enabled = false;
            weaponSlot.GetComponent<EquipedItem>().enabled = true;
        }
        else
        {
            weaponSlot.GetComponent<EquipedItem>().weapon = null;
            weaponSlot.GetComponent<Image>().enabled = false;
            weaponSlot.GetComponent<EquipedItem>().enabled = false;
        }

        if (trinketObject != null)
        {

            trinketSlot.GetComponent<Image>().enabled = true;
            trinketSlot.GetComponent<Image>().preserveAspect = true;
            trinketSlot.GetComponent<Image>().sprite = trinketObject.GetComponent<SpriteRenderer>().sprite;
            trinketSlot.GetComponent<EquipedItem>().weapon = trinketObject;
            trinketSlot.GetComponent<EquipedItem>().enabled = false;
            trinketSlot.GetComponent<EquipedItem>().enabled = true;
        }
        else
        {
            trinketSlot.GetComponent<EquipedItem>().weapon = null;
            trinketSlot.GetComponent<Image>().enabled = false;
            trinketSlot.GetComponent<EquipedItem>().enabled = false;
        }

    }
}
