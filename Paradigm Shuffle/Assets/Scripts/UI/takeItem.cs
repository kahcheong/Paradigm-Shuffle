using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class takeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tip;
    private readonly Vector3 hide = new Vector3(0, 0, 10);

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventory.inventor.stored >= 4) tip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tip.SetActive(false);
    }


    // Use this for initialization
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => TaskOnClick());
    }

    private void TaskOnClick()
    {
        if (inventory.inventor.stored < 4)
        {
            GameController.control.minDmg.GetComponent<Text>().text = "";
            GameController.control.dash.GetComponent<Text>().text = "";
            GameController.control.maxDmg.GetComponent<Text>().text = "";
            ItemCreation.creator.player.GetComponent<Player>().enabled = true;
            inventory.inventor.items[inventory.inventor.stored] = ItemCreation.creator.item.gameObject;
            ItemCreation.creator.item.gameObject.transform.position = hide;
            ItemCreation.creator.discard.SetActive(false);
            GameController.control.itemStat.SetActive(false);
            Destroy(ItemCreation.creator.gameObject);
            inventory.inventor.stored++;
            inventory.inventor.change();
            gameObject.SetActive(false);
        }

    }


}
