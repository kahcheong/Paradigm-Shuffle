using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trader : MonoBehaviour
{

    public static trader traderer;

    public GameObject text;
    private bool once = true;
    public GameObject spawner;
    public Weapon wep;
    private bool first;

    private void OnEnable()
    {
        traderer = this;

    }
    private void Start()
    {
        if (transform.childCount > 3) Destroy(transform.GetChild(3).gameObject);
    }
    private void OnDisable()
    {
        traderer = null;
    }

    private void Update()
    {
        if (transform.childCount > 3) Destroy(transform.GetChild(3).gameObject);

        if (wep != null && once)
        {
            once = false;
            text.GetComponent<Text>().text = "Step here to see what you get.";
            spawner.SetActive(true);
            spawner.transform.parent = null;
        }

        if (spawner == null) Destroy(gameObject);
    }
}
