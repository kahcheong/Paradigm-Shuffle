using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    // Use this for initialization
    public bool atk;
    public int atkType;
    public GameObject animation;
    public GameObject player;

    public GameObject[] hitBox;
    public float damage;

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
            animation.GetComponent<Animator>().Play("idle");
        }

        if (Input.GetMouseButtonDown(0) && !atk)
        {
            atk = true;
            StartCoroutine(Atacking());
            Debug.Log("clicking");
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) atkType = 1;
        if (Input.GetKeyDown(KeyCode.Keypad2)) atkType = 2;
        if (Input.GetKeyDown(KeyCode.Keypad3)) atkType = 3;
        if (Input.GetKeyDown(KeyCode.Keypad4)) atkType = 4;




    }

    IEnumerator Atacking()
    {
        if (atkType == 1)
        {
            animation.GetComponent<Animator>().Play("swipe");
            hitBox[0].SetActive(true);
            Debug.Log("attaking swipe");
            yield return new WaitForSeconds(0.16F);
        }
        if (atkType == 2)
        {
            GameObject atkk =  Instantiate(stab, player.transform.position,transform.rotation,player.transform);
            atkk.gameObject.tag = "playerAttack";
            atkk.transform.GetChild(0).gameObject.tag = "playerAttack";
            atkk.GetComponent<Stab>().damage = damage;
            Debug.Log("attaking stab");
            yield return new WaitForSeconds(1/4f);
        }
        if (atkType == 3)
        {
            GameObject atkk =  Instantiate(arrow, player.transform.position, transform.rotation * Quaternion.Euler(0,0,-90));
            atkk.gameObject.tag = "playerAttack";
            atkk.GetComponent<Shoot>().damage = damage;
            Debug.Log("shooting arrow");
            yield return new WaitForSeconds(1/2.5f);
        }
        if (atkType == 4)
        {
            GameObject atkk = Instantiate(bomb, player.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
            atkk.gameObject.tag = "playerAttack";
            atkk.GetComponent<Lob>().damage = damage;
            Debug.Log("throwing bomb");
            yield return new WaitForSeconds(1 /2f);
        }
        atk = false;
        for(int i = 0; i <hitBox.Length; i++)
        {
            hitBox[i].SetActive(false);
        }
        yield return true;
    }


    
}
