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
        change();
    }

    public void change()
    {
        if (items[0] != null){
            item0.GetComponent<Image>().enabled = true;
            item0.GetComponent<Image>().preserveAspect = true;
            item0.GetComponent<Image>().sprite = items[0].GetComponent<SpriteRenderer>().sprite;
            item0.GetComponent<takenItems>().weapon = items[0];
            item0.GetComponent<takenItems>().enabled = true;
        }
        else
        {
            item0.GetComponent<Image>().enabled = false;
            item0.GetComponent<takenItems>().enabled = false;
        }

        if (items[1] != null)
        {
            item1.GetComponent<Image>().enabled = true;
            item1.GetComponent<Image>().preserveAspect = true;
            item1.GetComponent<Image>().sprite = items[1].GetComponent<SpriteRenderer>().sprite;  
            item1.GetComponent<takenItems>().weapon = items[1];
            item1.GetComponent<takenItems>().enabled = true;
        }
        else
        {
            item1.GetComponent<Image>().enabled = false;
            item1.GetComponent<takenItems>().enabled = false;
        }

        if (items[2] != null)
        {
            item2.GetComponent<Image>().enabled = true;
            item2.GetComponent<Image>().preserveAspect = true;
            item2.GetComponent<Image>().sprite = items[2].GetComponent<SpriteRenderer>().sprite;
            item2.GetComponent<takenItems>().weapon = items[2];
            item2.GetComponent<takenItems>().enabled = true;
        }
        else
        {
            item2.GetComponent<Image>().enabled = false;
            item2.GetComponent<takenItems>().enabled = false;
        }

        if (items[3] != null)
        {
            item3.GetComponent<Image>().enabled = true;
            item3.GetComponent<Image>().preserveAspect = true;
            item3.GetComponent<Image>().sprite = items[3].GetComponent<SpriteRenderer>().sprite;
            item3.GetComponent<takenItems>().weapon = items[3];
            item3.GetComponent<takenItems>().enabled = true;
        }
        else
        {
            item3.GetComponent<Image>().enabled = false;
            item3.GetComponent<takenItems>().enabled = false;
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
