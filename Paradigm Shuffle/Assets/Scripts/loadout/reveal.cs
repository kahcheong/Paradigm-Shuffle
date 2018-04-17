using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class reveal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject card;
    private bool remove = false;
    public int id;

    public void OnPointerEnter(PointerEventData eventData)
    {
        remove = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        remove = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (card == null)
        {
            GetComponent<Image>().enabled = false;

        }
        else
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = card.GetComponent<SpriteRenderer>().sprite;
        }

        if (Input.GetMouseButtonDown(1) && remove)
        {
            CardChoice.choices.cards[id] = null;
            CardChoice.choices.restock();
            remove = false;
        }
    }
}
