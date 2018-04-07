using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreation : MonoBehaviour {

    public Card Card1;
    public Card Card2;
    public Card Card3;
    private Weapon weapon;

    public bool elite = false;
    private readonly Vector3 SpawnDisplay = new Vector3(0, 0, -5);
    private readonly Quaternion rotation = Quaternion.Euler(0, 0, 0);

    private int stat1;
    private int stat2;
    private int stat3;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.GetComponent<Player>().enabled = false;

            Card1 = GameController.control.GetCard();
            stat1 = Card1.GetComponent<Card>().id;

            if (stat1 % 10 == 9) elite = true;
            if (stat1 == 30) Destroy(gameObject.gameObject);

            GameObject item = Instantiate(Card1.item, SpawnDisplay, rotation);
            weapon = item.GetComponent<Weapon>();

            if (weapon.weapon)
            { 
                GameController.control.minDmg.GetComponent<Text>().text = weapon.minDamage.ToString();
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.maxDamage.ToString();

                Card2 = GameController.control.GetCard();
                stat2 = Card2.GetComponent<Card>().id;

                statChange(stat2);
            }





            //other.GetComponent<Player>().enabled = true;
            //Destroy(gameObject);

        }
    }

    void statChange(int weaponid)
    {
        float low = weapon.minDamage;
        float high = weapon.maxDamage;

        switch (weaponid)
        {
            case 0:
                low += 1;
                high += 1;
                break;
            case 1:
                low += 0;
                high += 2;
                break;
            case 2:
                low += 2;
                high += 0;
                break;




        }
    }


}
