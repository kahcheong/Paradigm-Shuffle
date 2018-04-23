using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tinkerer : MonoBehaviour {

    public static tinkerer tinker;

    public GameObject text;
    private bool once = true;
    public GameObject spawner;
    public Weapon wep;
    private bool first;

    private void OnEnable() 
    {
        tinker = this;
    }
    private void OnDisable()
    {
        tinker = null;
    }

    private void Update()
    {
        if (transform.childCount > 3) Destroy(transform.GetChild(3).gameObject);
        
        if (wep != null && once)
        {
            once = false;
            if (wep.weapon)
            {
                once = false;
                text.GetComponent<Text>().text = "Step here to see what you get.";
                spawner.SetActive(true);
                spawner.GetComponent<ItemCreation>().Card1 = wep.parentCard.GetComponent<Card>();
                spawner.transform.parent = null;
            }
            else
            {
                once = true;
            }
        }

        if (spawner == null) Destroy(gameObject);
    }
}
