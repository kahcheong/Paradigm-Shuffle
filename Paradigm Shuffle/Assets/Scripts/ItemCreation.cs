using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour {

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;

    public bool boss;

    private int stat1;
    private int stat2;
    private int stat3;

    public GameObject[] itemBase;







    // Use this for initialization
    void Awake () {
        stat1 = Card1.GetComponent<Card>().id;

        if (stat1 % 10 == 9) boss = true;
        



	}
	
	
}
