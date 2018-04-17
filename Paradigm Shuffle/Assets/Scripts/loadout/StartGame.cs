using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool enter;


    public void OnPointerEnter(PointerEventData eventData)
    {
        enter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        enter = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (enter && Input.GetMouseButtonDown(0))
        {
            foreach (GameObject g in CardChoice.choices.cards)
            {
                if (g != null) GameController.control.deck.Add(g.GetComponent<Card>());
            }
            SceneManager.LoadScene("Test");
        }
    }
}
