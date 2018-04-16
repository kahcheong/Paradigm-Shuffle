using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    private room home;
    public int side;                                     // 0 = left, 1 = right, 2 = up,, 3 = down
    private room next;
    public GameObject nextRoom;
    public GameObject spawn;

	// Use this for initialization
	void Start () {


        home = transform.parent.GetComponent<room>();
        next = home.rooms[side].GetComponent<room>();
        nextRoom = next.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="feet" && home.cleared)
        {
            FloorManager.floorManager.currRoom = nextRoom;
            other.gameObject.transform.parent.transform.position = nextRoom.GetComponent<room>().doors[((side) / 2 * 2 + 2 - (side) % 2) - 1].GetComponent<door>().spawn.transform.position + new Vector3(0,0,-0.1f);
        }
    }
}
