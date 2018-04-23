using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necro : MonoBehaviour {

    public GameObject skeletal;

    public GameObject spwn1;
    public GameObject spwn2;
    public GameObject spwn3;

    // Use this for initialization
    void OnEnable () {
        StartCoroutine(spawn());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawn()
    {
        GameObject other =  Instantiate(skeletal, spwn1.transform.position, spwn1.transform.rotation);
        other.transform.parent = FloorManager.floorManager.currRoom.transform;
        FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

        other = Instantiate(skeletal, spwn2.transform.position, spwn2.transform.rotation);
        other.transform.parent = FloorManager.floorManager.currRoom.transform;
        FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);

        other = Instantiate(skeletal, spwn3.transform.position, spwn3.transform.rotation);
        other.transform.parent = FloorManager.floorManager.currRoom.transform;
        FloorManager.floorManager.currRoom.GetComponent<room>().enemies.Add(other);


        yield return new WaitForSeconds(3);
        StartCoroutine(spawn());
    }
}
