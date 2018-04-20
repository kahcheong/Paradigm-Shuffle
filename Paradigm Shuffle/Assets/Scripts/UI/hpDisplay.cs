using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpDisplay : MonoBehaviour {

    //and cheats

    // Update is called once per frame
    void Update()
    {
        int temp = (int)Player.player.hp;
        if (temp < 0) temp = 0;
        GetComponent<Text>().text = temp + " / " + (int)Player.player.maxHp;
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.I)) Player.player.hp = Player.player.maxHp;
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.U)) Player.player.transform.GetChild(0).GetComponent<FollowMouse>().minDamage++;
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.J)) Player.player.transform.GetChild(0).GetComponent<FollowMouse>().maxDamage++;
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.M)) Player.player.transform.GetChild(0).GetComponent<FollowMouse>().atkSpeed++;
    }
}
