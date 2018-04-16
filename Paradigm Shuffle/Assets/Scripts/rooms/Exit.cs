using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "feet")
        {
            FloorManager.floorManager.cleanHouse();
            FloorManager.floorManager.loadFloor();
        }

   
    }
}
