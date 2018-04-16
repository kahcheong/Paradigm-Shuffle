using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public float playerSpeed; //speed player moves
    public bool hardLock;
    public GameObject decks;
    public Animator playerAnim;
    public bool GOD;

    private readonly float baseHp = 100;
    private readonly float baseMinAtk = 1;
    private readonly float baseMaxAtk = 1;
    private readonly float baseAtkSpeed = 1;

    public float hpLvl;
    public float damageLvl;
    //private float 

    public float trueHP;
    public float maxHp;
    public float hp;
    public float damageReducFlat;
    public float damageReducPercent;
    public float exp;

    private void Start()
    {
        if (player == null)
        {
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
        
        playerAnim = gameObject.GetComponent<Animator>();
        hp = maxHp;
    }

    void Update()
    {

        MoveForward(); // Player Movement 
        if (hp > maxHp) hp = maxHp;
        
    }

    public void newEquip()
    {
        float temp = 0;

        gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkType = 2;
        if (hp !=0 && maxHp !=0) temp = hp / maxHp;

        float temp100 = hpLvl;
        if (statBuff.stats.count > 0) temp100 = hpLvl + statBuff.stats.count;

        maxHp = trueHP * Mathf.Pow(1.1f,(temp100));


        if (equip.equipment.armorObject != null && equip.equipment.armorObject.GetComponent<Weapon>().percentReduc) maxHp *= equip.equipment.armorObject.GetComponent<Weapon>().percentReduction;
        if (equip.equipment.trinketObject != null && equip.equipment.trinketObject.GetComponent<Weapon>().percentReduc) maxHp *= equip.equipment.trinketObject.GetComponent<Weapon>().percentReduction;
        if (temp != 0) hp = maxHp * temp;
        else hp = maxHp;

        damageReducFlat = 0;
        if (equip.equipment.armorObject != null && equip.equipment.armorObject.GetComponent<Weapon>().flatReduc) damageReducFlat = equip.equipment.armorObject.GetComponent<Weapon>().flatReduction;
        if (equip.equipment.trinketObject != null && equip.equipment.trinketObject.GetComponent<Weapon>().flatReduc) damageReducFlat = equip.equipment.trinketObject.GetComponent<Weapon>().flatReduction;

        if (equip.equipment.weaponObject != null && equip.equipment.weaponObject.GetComponent<Weapon>().weapon)
        {
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().minDamage = equip.equipment.weaponObject.GetComponent<Weapon>().minDamage + damageLvl + statBuff.stats.count;
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().maxDamage = equip.equipment.weaponObject.GetComponent<Weapon>().maxDamage + damageLvl + statBuff.stats.count;
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkSpeed = equip.equipment.weaponObject.GetComponent<Weapon>().atkSpeed;
            if (equip.equipment.weaponObject.GetComponent<Weapon>().stab) gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkType = 2;
            if (equip.equipment.weaponObject.GetComponent<Weapon>().ranged) gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkType = 3;
            if (equip.equipment.weaponObject.GetComponent<Weapon>().lob) gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkType = 4;
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().minDamage = baseMinAtk + damageLvl + statBuff.stats.count;
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().maxDamage = baseMaxAtk + damageLvl + statBuff.stats.count;
            gameObject.transform.GetChild(0).GetComponent<FollowMouse>().atkSpeed = baseAtkSpeed;
        }
        if (GOD) damageReducFlat = 9999999;
    }

    void MoveForward()
    {

        if (hardLock)
        {

            if (Input.GetKey("a") && gameObject.transform.position.x > -6.46)//go left
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                playerAnim.Play("player_right");

                if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
                {
                    transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                }
                if (Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
                {
                    transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                }
            }
            else if (Input.GetKey("d") && gameObject.transform.position.x < 6.39)//go right
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_right");

                if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
                {
                    transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                }
                if (Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
                {
                    transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                }
            }
            else if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
            {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_up");
            }
            else if(Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_down");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_idle");
            }



        }
        else
        {
            if (Input.GetKey("w"))//go up
            {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("s"))//go down
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("a"))//go left
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("d"))//go right
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
