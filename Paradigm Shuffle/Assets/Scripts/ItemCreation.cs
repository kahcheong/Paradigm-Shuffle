using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour {

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject SpawnPoint;

    public bool boss;

    private int stat1;
    private int stat2;
    private int stat3;

    public GameObject[] itemBase;
    public GameObject decks;
    public SpawnRoom dc;

    // Use this for initialization
    void Awake () {
        stat1 = Card1.GetComponent<Card>().id;
        dc = decks.GetComponent<SpawnRoom>();


        if (stat1 % 10 == 9) boss = true;

        Instantiate(itemBase[stat1],SpawnPoint.transform) ;

        if (dc.deckSize > 0)
        {
            //temp1 = Random.Range(0, deckSize);
            dc.deckSize--;
        }

	}
	
	
}
