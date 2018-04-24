using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class Armour : MonoBehaviour
{

    public float minBase;
    public float maxBase;
    public int Cover; // Front, back or both (0,1,2) 

    public bool reduceDamage; // reduce incoming damage by this value
    public bool incDamage; // add damage to current weapon
    public bool incHp; // add maxBase a HP
  


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}