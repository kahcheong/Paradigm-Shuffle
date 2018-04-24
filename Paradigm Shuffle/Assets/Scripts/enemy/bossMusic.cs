using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMusic : MonoBehaviour {

    public GameObject boss;

    private void OnEnable()
    {
        if (GameController.control.gameObject.GetComponent<Music>().source == 1)
        {
            StartCoroutine(AudioFadeOut.FadeOut(GameController.control.gameObject.GetComponent<Music>().audio1, 1f));
            GameController.control.gameObject.GetComponent<Music>().audio2.Play();
            GameController.control.gameObject.GetComponent<Music>().source = 2;
        }
    }

 

    private void OnDisable()
    {
        if (GameController.control.gameObject.GetComponent<Music>().source == 2)
        {
            GameController.control.gameObject.GetComponent<Music>().StopBoss();
            GameController.control.gameObject.GetComponent<Music>().audio1.Play();
            GameController.control.gameObject.GetComponent<Music>().source = 1;
        }
    }

    private void OnDestroy()
    {
        if (GameController.control.gameObject.GetComponent<Music>().source == 2)
        {
            GameController.control.gameObject.GetComponent<Music>().StopBoss();
            GameController.control.gameObject.GetComponent<Music>().audio1.Play();
            GameController.control.gameObject.GetComponent<Music>().source = 1;
        }
    }

}
