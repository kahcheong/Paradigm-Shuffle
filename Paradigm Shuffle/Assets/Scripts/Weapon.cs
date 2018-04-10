using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Weapon : MonoBehaviour
{

    public float minDamage;
    public float maxDamage;
    public float minRange;
    public float maxRange;
    public float atkSpeed;
    public float flatReduction;
    public float percentReduction; //buff hp instead
    public float[] buff;
    public int level;


    public bool weapon;
    public bool flatReduc;
    public bool percentReduc;
    public bool trinket;
    public bool consume;

    public bool stab;
    public bool lob;
    public bool ranged;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}