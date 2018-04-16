using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class discardItem : MonoBehaviour
{


    // Use this for initialization
    void OnEnable()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => TaskOnClick());
    }

    private void TaskOnClick()
    {

        GameController.control.minDmg.GetComponent<Text>().text = "";
        GameController.control.dash.GetComponent<Text>().text = "";
        GameController.control.maxDmg.GetComponent<Text>().text = "";
        ItemCreation.creator.player.GetComponent<Player>().enabled = true;
        Destroy(ItemCreation.creator.item.gameObject);
        GameController.control.takeUI.SetActive(false);
        GameController.control.itemStat.SetActive(false);
        Destroy(ItemCreation.creator.gameObject);
        gameObject.SetActive(false);
    }

    


}
