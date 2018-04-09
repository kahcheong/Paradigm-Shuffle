using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreation : MonoBehaviour {

    public static ItemCreation creator;

    public Card Card1;
    public Card Card2;
    public Card Card3;
    private Weapon weapon;
    public GameObject item;
    private bool hold;
    public int stage = 0;
    public GameObject cardDisplay;
    public GameObject take;
    public GameObject discard;
    private Button taker;
    private Button discarder;
    public GameObject player;

    public bool elite = false;
    private readonly Vector3 SpawnDisplay = new Vector3(0, 0, -5);
    private readonly Quaternion rotation = Quaternion.Euler(0, 0, 0);
    private readonly Vector3 cardSpawn = new Vector3(-13.8f,2.3f,0);

    private int stat1;
    private int stat2;
    private int stat3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.control.itemStat.SetActive(true);
            other.gameObject.GetComponent<Player>().enabled = false;
            player = other.gameObject;

            Card1 = GameController.control.GetCard();
            stat1 = Card1.GetComponent<Card>().id;

            if (stat1 % 10 == 9) elite = true;
            if (stat1 == 30) Destroy(gameObject.gameObject);

            

            GameObject card =  Instantiate(cardDisplay, GameController.control.itemStat.transform);
            card.GetComponent<Image>().sprite = Card1.card.GetComponent<SpriteRenderer>().sprite;
            StartCoroutine(wait(2.5f));

        }
    }

    private void Update()
    {
        if (stage == 1)
        {
            item = Instantiate(Card1.item, SpawnDisplay, rotation);
            weapon = item.GetComponent<Weapon>();

            if (weapon.weapon)
            {
                GameController.control.minDmg.GetComponent<Text>().text = weapon.minDamage.ToString();
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.maxDamage.ToString();

                stage++;
                StartCoroutine(wait(2.5f));

            }
            else if (weapon.flatReduc)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Reduce damage Taken by";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.flatReduction.ToString();

                stage++;
                StartCoroutine(wait(2.5f));
            }
            else if (weapon.percentReduc)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Increase HP by";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.percentReduction.ToString();

                stage++;
                StartCoroutine(wait(2.5f));
            }
        }
        else if (stage == 2)
        {
            Card2 = GameController.control.GetCard();
            stat2 = Card2.GetComponent<Card>().id;
            GameObject card2 = Instantiate(cardDisplay, GameController.control.itemStat.transform);
            card2.GetComponent<Image>().sprite = Card2.card.GetComponent<SpriteRenderer>().sprite;
            stage++;
            StartCoroutine(wait(2.5f));
        }
        else if (stage == 4)
        {
            if (weapon.weapon)
            {
                statChange(stat2);
                GameController.control.minDmg.GetComponent<Text>().text = weapon.minDamage.ToString();
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.maxDamage.ToString();

                stage++;

            }     
        }
        else if (stage >= 5)
        {
            creator = this;
            take.SetActive(true);
            discard.SetActive(true);
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

    void showCard()
    {

    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        stage++;

    }

}
