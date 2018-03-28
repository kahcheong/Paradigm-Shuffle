using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    // Use this for initialization
    public bool atk;
    public int atkType;
    public GameObject animation;

    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
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
            Debug.Log("attaking swipe");
            yield return new WaitForSeconds(0.10F);
        }
        if (atkType == 2)
        {
            animation.GetComponent<Animator>().Play("stab");
            Debug.Log("attaking stab");
            yield return new WaitForSeconds(0.09F);
        }
        atk = false;
        yield return true;
    }


    
}
