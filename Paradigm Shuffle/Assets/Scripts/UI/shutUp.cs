using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shutUp : MonoBehaviour {

    private void OnLevelWasLoaded(int level)
    {
        GameController.control.gameObject.GetComponent<AudioSource>().mute = true;
    }

    private void OnDestroy()
    {
        GameController.control.gameObject.GetComponent<AudioSource>().mute = false;
        GameController.control.gameObject.GetComponent<Music>().playRandomMusic();
    }
}
