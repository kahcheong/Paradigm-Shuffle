using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController control;

    public GameObject itemStat;
    public GameObject minDmg;
    public GameObject dash;
    public GameObject maxDmg;
    public GameObject atkSpeed;
    public GameObject cardDisplay;
    public bool[] unlockedCards = new bool[30];


    public GameObject spawnLoc;
    public int deckSize;

    public List<Card> deck = new List<Card>();
    public List<Card> discard = new List<Card>();
    public List<Card> availCards = new List<Card>();
    public List<Card> npcDeck = new List<Card>();

    // Use this for initialization
    void Start () {

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

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
    }

    public void LoadRoom (Card c1, Card c2)
    {
        var card1 = Instantiate(c1, spawnLoc.transform);

        var card2 = Instantiate(c2, spawnLoc.transform);

    }

    public Card GetCard()
    {
            int temp1 = 0;
            if (deckSize !=0)
            {
                temp1 = Random.Range(0, deckSize);
                deckSize--;
            }
            else
            {
                ReShuffleDeck();
                temp1 = Random.Range(0, deckSize);
                deckSize--;
            }

            Card temp4 = deck[temp1];
            deck.RemoveAt(temp1);
            discard.Add(temp4);

        return (temp4);
    }

    public void ReShuffleDeck()
    {
        deck.AddRange(discard);
        discard.Clear();
        deckSize = 10;
    }
}
