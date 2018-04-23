using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class library : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject info;
    public GameObject hide;
    public GameObject card;
    private bool canClick = false;
    public int id;
    private int count = 0;

    public void Start()
    {
        hide = GameObject.Find("CB");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info.SetActive(true);
        hide.SetActive(false);
        canClick = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.SetActive(false);
        hide.SetActive(true);
        canClick = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            if (CardChoice.choices != null && CardChoice.choices.cards[CardChoice.choices.cards.Length - 1] == null)
            {
                CardChoice.choices.cards[CardChoice.choices.size] = card;
                CardChoice.choices.size++;
            }

        }
        if (GameController.control.unlockedCards[id] == false)
        {
             Destroy(gameObject);
        }
    }

  
}
