using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    private static Random rng = new Random();
    public static GameController control;

    public GameObject itemStat;
    public GameObject minDmg;
    public GameObject dash;
    public GameObject maxDmg;
    public GameObject atkSpeed;
    public GameObject cardDisplay;
    public GameObject roomDisplay;
    public int level = 1;
    public bool[] unlockedCards = new bool[30];
    public GameObject buuf;
    public int elitesSlain;
    public GameObject flames;

    public GameObject takeUI;
    public GameObject discardUI;

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

        
	}
	
	// Update is called once per frame
	void Update () {

        if (deckSize == 0) ReShuffleDeck();
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
    public void setNPCDeck()
    {
        npcDeck.Clear();
        if (FloorManager.floorManager != null && FloorManager.floorManager.floor % 10 == 0)
        {
            for (int i =0; i < 7; i++)
            {
                npcDeck.Add(availCards[(Random.Range(1, 3) * 10)-1]);
            }
            for (int i = 0; i < 3; i++)
            {
                npcDeck.Add(availCards[Random.Range(0,29)]);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                npcDeck.Add(availCards[Random.Range(0, 29)]);
            }
        }
    }
    public void removeNpc()
    {
        foreach (Card c in npcDeck)
        {
            deck.Remove(c);
        }
    }

    public void ReShuffleDeck()
    {
        deck.AddRange(discard);
        discard.Clear();
        List<Card> temp = new List<Card>();
        for (int i = 0; i < deck.Count; i++)
        {
            int temp67 = Random.Range(0, deck.Count);
            Card temp90 = deck[temp67];
            temp.Add(temp90);
            deck.Remove(temp90);
        }
        deck.AddRange(temp);

        deckSize = deck.Count;
    }

    


}
