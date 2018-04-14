using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrage : MonoBehaviour {


    private Enemy me;
    private Player ply;
    private FollowMouse weapon;


    // Use this for initialization
    private void Awake()
    {
        ply = GameObject.Find("player").GetComponent<Player>();
        me = gameObject.GetComponent<Enemy>();
        weapon = GameObject.Find("player").transform.GetChild(0).gameObject.GetComponent<FollowMouse>();

        me.maxHp = ply.maxHp;
        me.hp = me.maxHp;
        me.minDamage = weapon.minDamage;
        me.maxDamage = weapon.maxDamage;
        me.minRange = 1;
        me.damageReducFlat = ply.damageReducFlat;
        me.damageReducPercent = ply.damageReducPercent;
        me.moveSpeed = ply.playerSpeed;

        
    }

    private void Update()
    {
        if (weapon.atkType == 2)
        {
            me.ranged = false;
            me.lob = false;
            me.stab = true;
            me.atkSpeed = weapon.atkSpeed;
            me.weapon = weapon.stab;
        }
        if (weapon.atkType == 3)
        {
            me.lob = false;
            me.stab = false;
            me.ranged = true;
            me.atkSpeed = weapon.atkSpeed;
            me.weapon = weapon.arrow;
        }
        if (weapon.atkType == 4)
        {
            me.ranged = false;
            me.stab = false;
            me.lob = true;
            me.atkSpeed = weapon.atkSpeed;
            me.weapon = weapon.bomb;
        }
    }
}
