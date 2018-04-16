using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statBuff : MonoBehaviour
{

    public static statBuff stats;


    public int count;
    private Image image;
    private int prevCount;

    private void OnEnable()
    {
        if (stats == null)
        {
            stats = this;
        }
        else if (stats != this)
        {
            Destroy(this);
        }

        image = GetComponent<Image>();
        count = 1;
        prevCount = 0;
    }

    private void Update()
    {
        
        if (count <= 0)
        {
            image.enabled = false;
            count = 0;
        }
        else
        {
            image.enabled = true; 
        }
        if (count != prevCount) Player.player.newEquip();
        prevCount = count;

    }

}
