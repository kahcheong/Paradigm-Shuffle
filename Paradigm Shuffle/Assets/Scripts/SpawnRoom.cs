using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour {

    public playerDeck deck;
    public GameObject spawnLoc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            LoadRoom(deck.deck[Random.Range(0, deck.deck.Length)], deck.deck[Random.Range(0, deck.deck.Length)]);
        }
	}

    void LoadRoom (Card c1, Card c2)
    {

    }
}
