using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class showDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Texts;
    public GameObject Base;
    private List<GameObject> delete = new List<GameObject>();
    private readonly Vector3 deckSpawn = new Vector3(50, 0, 0);
    private readonly Vector3 discardSpawn = new Vector3(0, -85, 0);

    public void OnPointerEnter(PointerEventData eventData)
    {
        Texts.SetActive(true);
        int i = 1;
        foreach (Card c in GameController.control.deck)
        {
            GameObject temp = Instantiate(Base, transform.position + deckSpawn * i, transform.rotation, transform);
            temp.GetComponent<Image>().sprite = c.card.GetComponent<SpriteRenderer>().sprite;

            temp.transform.localScale = new Vector3(1, 1, 1);
            delete.Add(temp);
            i++;
        }
        int j = 1;
        foreach (Card c in GameController.control.discard)
        {
            GameObject temp = Instantiate(Base, transform.position + deckSpawn * j + discardSpawn, transform.rotation, transform);
            temp.GetComponent<Image>().sprite = c.card.GetComponent<SpriteRenderer>().sprite;

            temp.transform.localScale = new Vector3(1, 1, 1);
            delete.Add(temp);
            j++;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Texts.SetActive(false);

        foreach (GameObject g in delete)
        {
            Destroy(g);
        }
    }

}
