using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

    public static inventory inventor;

    public GameObject[] items =  new GameObject[4];
    public GameObject item0;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject inv;
    public int stored;

    private bool showInventory;

    // Use this for initialization
    void Start () {
        if (inventor == null)
        {
            inventor = this;
        }
        else if (inventor != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)) showInventory = !showInventory;
	}
    public void change()
    {
        if (items[0] != null){
            item0.GetComponent<Image>().enabled = true;
            item0.GetComponent<Image>().sprite = items[0].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            item0.GetComponent<Image>().enabled = false;
        }

        if (items[1] != null)
        {
            item1.GetComponent<Image>().enabled = true;
            item1.GetComponent<Image>().sprite = items[1].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            item1.GetComponent<Image>().enabled = false;
        }

        if (items[2] != null)
        {
            item2.GetComponent<Image>().enabled = true;
            item2.GetComponent<Image>().sprite = items[2].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            item2.GetComponent<Image>().enabled = false;
        }

        if (items[3] != null)
        {
            item3.GetComponent<Image>().enabled = true;
            item3.GetComponent<Image>().sprite = items[3].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            item3.GetComponent<Image>().enabled = false;
        }
    }

    public void Reset(int pos)
    {
        for ( int i = pos; i < 3; i++)
        {
            items[pos] = items[pos + 1];
        }
        change();
    }

}
