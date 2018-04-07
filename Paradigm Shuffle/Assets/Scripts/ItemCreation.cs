using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour {

    public Card Card1;
    public Card Card2;
    public Card Card3;

    public bool elite = false;

    private int stat1;
    private int stat2;
    private int stat3;


    // Use this for initialization
    void Awake () {
        Card1 = GameController.control.GetCard();

        stat1 = Card1.GetComponent<Card>().id;

        if (stat1 % 10 == 9) elite = true;
        if (stat1 == 30) Destroy(gameObject.gameObject);





	}
	
	
}
