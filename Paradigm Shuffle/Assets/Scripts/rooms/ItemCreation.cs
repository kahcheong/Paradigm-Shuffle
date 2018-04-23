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
    private readonly Vector3 split = new Vector3(3, 0, 0);
    private readonly Vector3 SpawnDisplay = new Vector3(0, 0, -5);
    private readonly Quaternion rotation = Quaternion.Euler(0, 0, 0);
    private readonly Vector3 cardSpawn = new Vector3(-13.8f,2.3f,0);

    private int stat1;
    private int stat2;
    private int stat3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "feet")
        {

            GameController.control.minDmg.GetComponent<Text>().text = "";
            GameController.control.dash.GetComponent<Text>().text = "";
            GameController.control.maxDmg.GetComponent<Text>().text = "";
            GameController.control.atkSpeed.GetComponent<Text>().text = "";

            GameController.control.itemStat.SetActive(true);
            other.gameObject.transform.parent.GetComponent<Player>().enabled = false;
            player = other.transform.parent.gameObject;

            if (Card1 == null) Card1 = GameController.control.GetCard();
            stat1 = Card1.GetComponent<Card>().id;

            if (stat1 % 10 == 9)
            {
                elite = true;
                GameObject others = Instantiate(gameObject, gameObject.transform.position + split, gameObject.transform.rotation,gameObject.transform.parent.transform);
                others.GetComponent<ItemCreation>().Card1 = null;
                others = Instantiate(gameObject, gameObject.transform.position - split, gameObject.transform.rotation, gameObject.transform.parent.transform);
                others.GetComponent<ItemCreation>().Card1 = null;
                Destroy(gameObject.gameObject);
                player.GetComponent<Player>().enabled = true;
            }
            if (stat1 == 30)
            {
                Destroy(gameObject.gameObject);
                player.GetComponent<Player>().enabled = true;
            }


            GameObject card = Instantiate(cardDisplay, GameController.control.itemStat.transform);
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
            weapon.level = FloorManager.floorManager.floor;
            int temp25 = FloorManager.floorManager.floor / 10;
            weapon.minDamage *= ((1 + (temp25 / 10f)));
            weapon.maxDamage *= ((1 + (temp25 / 10f)));

            if (weapon.weapon)
            {

                GameController.control.minDmg.GetComponent<Text>().text = weapon.minDamage.ToString();
                GameController.control.dash.GetComponent<Text>().text = " - ";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.maxDamage.ToString();
                GameController.control.atkSpeed.GetComponent<Text>().text = weapon.atkSpeed.ToString() + " attacks per second";

                stage++;
                StartCoroutine(wait(2.5f));

            }
            else if (weapon.flatReduc)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Reduce damage Taken by";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.flatReduction.ToString();
                GameController.control.atkSpeed.GetComponent<Text>().text = "";

                stage++;
                StartCoroutine(wait(2.5f));
            }
            else if (weapon.percentReduc)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Increase HP by";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                GameController.control.maxDmg.GetComponent<Text>().text = (((int)((weapon.percentReduction - 1) * 1000)) / 10f).ToString() + "%";
                GameController.control.atkSpeed.GetComponent<Text>().text = "";

                stage++;
                StartCoroutine(wait(2.5f));
            }
            else if (weapon.consume)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Heals for ";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                if (stat1 == 18) weapon.stacks = 3;
                if (stat1 == 22) weapon.stacks = 1;

                GameController.control.maxDmg.GetComponent<Text>().text = "? on cosume. stock:" + weapon.stacks;
                GameController.control.atkSpeed.GetComponent<Text>().text = "";

                stage++;
                StartCoroutine(wait(2.5f));
            }
            else if (weapon.xp)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Gain ";
                GameController.control.dash.GetComponent<Text>().text = " : ";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.minDamage + "EXP" ;
                GameController.control.atkSpeed.GetComponent<Text>().text = "";

                stage++;
                StartCoroutine(wait(2.5f));
            }
            else if (weapon.statBuff)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Gain 1 level in both   ";
                GameController.control.dash.GetComponent<Text>().text = " stats";
                GameController.control.maxDmg.GetComponent<Text>().text = "    till the end of the floor";
                GameController.control.atkSpeed.GetComponent<Text>().text = "";
                GameController.control.buuf.GetComponent<statBuff>().count++;

                stage++;
                StartCoroutine(wait(2.5f));

            }
            else if (weapon.GODPOTION)
            {
                GameController.control.minDmg.GetComponent<Text>().text = "Keeps you invinsible for ";
                GameController.control.dash.GetComponent<Text>().text = "";
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.minDamage+ "secs";
                GameController.control.atkSpeed.GetComponent<Text>().text = "";

                stage++;
                StartCoroutine(wait(2.5f));
            }
        }
        else if (stage == 2)
        {
            if (Card2 == null) Card2 = GameController.control.GetCard();
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
                GameController.control.atkSpeed.GetComponent<Text>().text = weapon.atkSpeed.ToString() + " attacks per second";

                stage++;

            }    
            if (weapon.consume)
            {
                weapon.minDamage = (stat2 % 10 +1 )*5;
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.minDamage + " on cosume. stock:" + weapon.stacks;
                stage++;
            }
            if (weapon.xp)
            {
                weapon.minDamage = (stat2 % 10 + 1) * 5;
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.minDamage + "EXP";
                Player.player.exp += weapon.minDamage;
                StartCoroutine(wait(2.5f));

            }
            if (weapon.GODPOTION)
            {
                weapon.minDamage += (stat2 % 10 + 1) * 2;
                GameController.control.maxDmg.GetComponent<Text>().text = weapon.minDamage + "secs";
                stage++;
            }
        }
        else if (stage >= 5)
        {
            creator = this;
            if (!weapon.xp && !weapon.statBuff) GameController.control.takeUI.SetActive(true);
            GameController.control.discardUI.SetActive(true);

        }

    }

    void statChange(int weaponid)
    {
        float low = weapon.minDamage;
        float high = weapon.maxDamage;
        float spd = weapon.atkSpeed;
       
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
                spd *= 2; 
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
                spd *= 4;
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
                spd *= 1.5f;
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
                spd *= 3;
                break;
            case 25:
                low *= 2.5f;
                high *= 4f;
                spd *= 0.5f;
                break;
            case 26:
                low *= .7f;
                high *= .7f;
                spd *= 2;
                break;
            case 27:
                low *= 1f;
                high *= 1.6f;
                spd *= 3;
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

        
        if (low < 0) low = 0;
        if (low > high) high = low;
        weapon.minDamage = low;
        weapon.maxDamage = high;
        weapon.atkSpeed = spd;
    }
    
    IEnumerator waitNo(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        stage++;

    }

}
