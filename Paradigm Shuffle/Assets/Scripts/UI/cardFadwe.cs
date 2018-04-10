using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardFadwe : MonoBehaviour {

    private Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        StartCoroutine(wait());

    }
	

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(fade());
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator fade()
    {
        while (true)
        {
            Color c = image.color;
            c.a -= 0.01f;
            image.color = c;
            yield return true;
        }


    }

}
