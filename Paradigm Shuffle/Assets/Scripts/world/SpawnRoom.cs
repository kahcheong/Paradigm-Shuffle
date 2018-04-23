using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public GameObject spawnLoc;
    public int deckSize;

    public List<Card> deck = new List<Card>();
    public List<Card> discard = new List<Card>();
    public List<Card> availCards = new List<Card>();
    public List<Card> npcDeck = new List<Card>();

    // Use this for initialization
    void Start () {
        deckSize+=10;
        deck.AddRange(npcDeck);
	}
	
	// Update is called once per frame
	void Update () {

        if (deckSize == 0) ReShuffleDeck();

        if (Input.GetKeyDown(KeyCode.P)) // room load
        {
            int temp1 = 0;
            int temp2 = 0;
            if (deckSize >= 2)
            {
                temp1 = Random.Range(0, deckSize);
                deckSize--;
                temp2 = Random.Range(0, deckSize);
                deckSize--;
            }
            else
            {
                ReShuffleDeck();
                temp1 = Random.Range(0, deckSize);
                deckSize--;
                temp2 = Random.Range(0, deckSize);
                deckSize--;
            }

            Card temp3 = deck[temp1];
            deck.RemoveAt(temp1);
            discard.Add(temp3);

            Card temp4 = deck[temp2];
            deck.RemoveAt(temp2);
            discard.Add(temp4);

            LoadRoom(temp3, temp4);
            
        }

        if (Input.GetKeyDown(KeyCode.O)) // item creation
        {
            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;
            if (deckSize >= 3)
            {
                temp1 = Random.Range(0, deckSize);
                deckSize--;
                temp2 = Random.Range(0, deckSize);
                deckSize--;
                temp3 = Random.Range(0, deckSize);
                deckSize--;
            }
            else
            {  
                ReShuffleDeck();
                temp1 = Random.Range(0, deckSize);
                deckSize--;
                temp2 = Random.Range(0, deckSize);
                deckSize--;
                temp3 = Random.Range(0, deckSize);
                deckSize--;
            }

            Card temp4 = deck[temp1];
            deck.RemoveAt(temp1);
            discard.Add(temp4);

            Card temp5 = deck[temp2];
            deck.RemoveAt(temp2);
            discard.Add(temp5);

            Card temp6 = deck[temp3];
            deck.RemoveAt(temp3);
            discard.Add(temp6);

            CreateItem(temp4, temp5,temp6);
            
        }
    }

    void LoadRoom (Card c1, Card c2)
    {
        var card1 = Instantiate(c1, spawnLoc.transform);

        var card2 = Instantiate(c2, spawnLoc.transform);

    }

    void CreateItem(Card c1, Card c2, Card c3)
    {
        var card1 = Instantiate(c1, spawnLoc.transform);

        var card2 = Instantiate(c2, spawnLoc.transform);

        var card3 = Instantiate(c2, spawnLoc.transform);

    }

    void ReShuffleDeck()
    {
        deck.AddRange(discard);
        discard.Clear();
        deckSize = 10;
    }
}
