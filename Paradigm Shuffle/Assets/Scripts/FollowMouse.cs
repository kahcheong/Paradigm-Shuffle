using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    // Use this for initialization
    public bool atk;
    public int atkType;
    public GameObject player;
    public float atkSpeed;

    public float minDamage;
    public float maxDamage;

    public GameObject stab;
    public GameObject arrow;
    public GameObject bomb;

    void Update()
    {
        player = GameObject.Find("player");
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (!atk)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetMouseButton(0))
        {
            if (!atk)
            {
                atk = true;
                StartCoroutine(Atacking());
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) atkType = 1;
        if (Input.GetKeyDown(KeyCode.Keypad2)) atkType = 2;
        if (Input.GetKeyDown(KeyCode.Keypad3)) atkType = 3;
        if (Input.GetKeyDown(KeyCode.Keypad4)) atkType = 4;




    }

    IEnumerator Atacking()
    {

        if (atkType == 2)
        {
            GameObject atkk =  Instantiate(stab, player.transform.position,transform.rotation);
            atkk.transform.parent = player.transform;
            atkk.gameObject.tag = "playerAttack";
            atkk.transform.GetChild(0).gameObject.tag = "playerAttack";
            atkk.GetComponent<Stab>().damage = Random.Range(minDamage,maxDamage);
            //Debug.Log("attaking stab");
            yield return new WaitForSeconds(1f/atkSpeed);
        }
        if (atkType == 3)
        {
            GameObject atkk =  Instantiate(arrow, player.transform.position, transform.rotation * Quaternion.Euler(0,0,-90));
            atkk.gameObject.tag = "playerAttack";
            atkk.GetComponent<Shoot>().damage = Random.Range(minDamage, maxDamage);
            //Debug.Log("shooting arrow");
            yield return new WaitForSeconds(1f/atkSpeed);
        }
        if (atkType == 4)
        {
            GameObject atkk = Instantiate(bomb, player.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
            atkk.gameObject.tag = "playerAttack";
            atkk.GetComponent<Lob>().damage = Random.Range(minDamage, maxDamage);
            //Debug.Log("throwing bomb");
            yield return new WaitForSeconds(1f /atkSpeed);
        }
        atk = false;

        yield return true;
    }


    
}
