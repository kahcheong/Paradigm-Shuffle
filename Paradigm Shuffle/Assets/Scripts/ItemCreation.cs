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
    private readonly Vector3 SpawnDisplay = new Vector3(0, 0, -10);
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
            case 3:
                low += 1;
                high += 3;
                break;
            case 4:
                low -= 1;
                high += 3;
                break;
            case 5:
                low *= .5f;
                high *= .7f;
                break;
            case 6:
                low += 2;
                high += 2;
                break;
            case 7:
                low += 2;
                high += 5;
                break;
            case 8:
                low *= .3f;
                high *= .4f;
                break;
            case 9:
                low *= 2f;
                high *= 2f;
                break;
            case 10:
                low += 2;
                high += 3;
                break;
            case 11:
                low += 2;
                high += 5;
                break;
            case 12:
                low -= 1;
                high += 5;
                break;
            case 13:
                low -= 2;
                high += 2;
                break;
            case 14:
                low -= 5;
                high += 10;
                break;
            case 15:
                low -= 2;
                high += 5;
                break;
            case 16:
                low -= 3;
                high -= 3;
                break;
            case 17:
                float range1 = high - low;
                high -= range1 / 4;
                low += range1 / 4;
                low *= 1.4f;
                high *= 1.6f;
                break;
            case 18:
                low += 0;
                high += 0;
                break;
            case 19:
                low *= 1.5f;
                high *= 3f;
                break;
            case 20:
                low += 0;
                high *= 2;
                break;
            case 21:
                low *= 2f;
                high += 0;
                break;
            case 22:
                float range2 = high - low;
                high -= range2 / 2;
                low += range2 / 2;
                break;
            case 23:
                float range3 = high - low;
                high += range3 / 4;
                low -= range3 / 4;
                break;
            case 24:
                low *= .6f;
                high += 0;
                break;
            case 25:
                low *= 2.5f;
                high *= 4f;
                break;
            case 26:
                low *= .7f;
                high *= .7f;
                break;
            case 27:
                low *= 1f;
                high *= 1.6f;
                break;
            case 28:
                low = high;
                break;
            case 29:
                low += 0;
                high *= 5;
                break;
            case 30:
                low += 0;
                high += 0;
                break;


        }

        if (low > high) high = low;
        weapon.minDamage = low;
        weapon.maxDamage = high;
    }


}
