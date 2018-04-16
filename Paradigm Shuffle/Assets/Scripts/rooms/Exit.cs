using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    public GameObject inside;
    private SpriteRenderer image; 

    private void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "feet")
        {
            FloorManager.floorManager.cleanHouse();
            FloorManager.floorManager.loadFloor();
        }

   
    }

    private void OnEnable()
    {
        image = GetComponent<SpriteRenderer>();
        StartCoroutine(mood2());
    }

    IEnumerator mood()
    {
        while (true)
        {
            Color c = image.color;
            float h, s, v;
            Color.RGBToHSV(c, out h, out s, out v);
            h += 0.05f;
            if (h > 0.95f) h = 0;
            c = Color.HSVToRGB(h, s, v);
            image.color = c;
            yield return true;
        }
    }

    IEnumerator mood2()
    {
        while (true)
        {
            Color c = image.color;
            c.r += Random.Range(0, 0.1f);
            c.g += Random.Range(0, 0.05f);
            c.b += Random.Range(0, 0.01f);
            if (c.r > 0.95f) c.r = 0;
            if (c.g > 0.95f) c.g = 0;
            if (c.b > 0.95f) c.b = 0;
            image.color = c;
            yield return true;
        }
    }
}
