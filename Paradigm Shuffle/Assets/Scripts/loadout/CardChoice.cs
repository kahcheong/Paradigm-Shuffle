using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChoice : MonoBehaviour {

    public static CardChoice choices;

    public GameObject[] cards = new GameObject[10];
    public GameObject[] reveal = new GameObject[10];
    public int size = 0;

    // Use this for initialization
    void Start () {
		if (choices == null)
        {
            choices = this;
        }
        else if (choices != this)
        {
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 10; i++)
        {
            reveal[i].GetComponent<reveal>().card = cards[i];
        }
	}

    public void restock()
    {
        int pos = 9;
        for (int i = 8; i >=0; i--)
        {
            if (cards[i] == null) pos = i;
        }

        for (int i = pos; i < 9; i++)
        {
            cards[i] = cards[i + 1];
        }
        cards[size-1] = null;
        size--;
    }
}
