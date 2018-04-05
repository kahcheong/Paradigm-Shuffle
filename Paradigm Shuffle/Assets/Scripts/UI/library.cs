using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class library : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject info;
    public GameObject hide;

    public void Start()
    {
        hide = GameObject.Find("CB");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info.SetActive(true);
        hide.SetActive(false);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.SetActive(false);
        hide.SetActive(true);
    }

}
