using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    public static FloorManager floorManager;

    public int floor = 0;
    public GameObject currRoom;
    public GameObject[] availRooms = new GameObject[4];
    public GameObject[] floorRooms;
    public int floorSize;
    private bool giveExit;

	// Use this for initialization
	void Start () {
		if (floorManager == null)
        {
            floorManager = this;
        }
        else if (floorManager != this)
        {
            Destroy(this);
        }
        loadFloor();

	}
	
	// Update is called once per frame
	void Update () {
        if (currRoom.active != true)
        {
            currRoom.GetComponent<room>().enabled = true;
            currRoom.SetActive(true);
        }
        foreach (GameObject g in floorRooms)
        {
            if (g != currRoom)
            {
                //g.GetComponent<room>().enabled = false;
                g.SetActive(false);
            }
        }
    }

    public void loadFloor()
    {
        floor++;
        floorSize = Random.Range(10, 15);
        floorRooms = new GameObject[floorSize];

        for (int i = 0; i < floorSize; i++)
        {
            floorRooms[i] = Instantiate (availRooms[Random.Range(0, 3)]);
            floorRooms[i].GetComponent<room>().enabled = false;
            floorRooms[i].SetActive(false);
        }


        currRoom = floorRooms[0];
        for (int i = 1; i < floorSize; i++)
        {
            connectRoom(i-1, floorRooms[i]);
        }
        
    }

    public void connectRoom (int setUpedRooms, GameObject r2)
    {
        int temp3 = 0;
        if (setUpedRooms != 0) temp3 = Random.Range(0, setUpedRooms);
        
        GameObject starterRoom = floorRooms[temp3];
        room rOrigin = starterRoom.GetComponent<room>();
        room rAdd = r2.GetComponent<room>();

        int temp1 = -1;
        for (int i = 0; i < 4; i++)
        {
            if (rOrigin.rooms[i] == null) temp1++;
        }
        if (temp1 != -1) ;
        bool linked = false;
        int temp2 = Random.Range(0, temp1);
        if (temp1 == -1)  connectRoom(setUpedRooms, r2);
        else
        {
            while (!linked)
            {
                if (rOrigin.rooms[temp2] != null)
                {
                    temp2++;
                }
                else
                {
                    rOrigin.rooms[temp2] = r2;
                    rAdd.rooms[((temp2 ) / 2 * 2 + 2 - (temp2 ) % 2) -1] = starterRoom;
                    linked = true;
                    
                }
            }
        }

    }
}
