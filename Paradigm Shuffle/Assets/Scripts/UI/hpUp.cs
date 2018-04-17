using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => TaskOnClick());
    }

    // Update is called once per frame

    private void TaskOnClick()
    {
        Player.player.hpLvl++;
        Player.player.exp -= 100;
        transform.parent.GetComponent<EXP>().lvlUp = false;

    }
}
