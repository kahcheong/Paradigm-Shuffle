using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bonusCard : MonoBehaviour {

    private int pos = 0;
    public GameObject oof;
    // Use this for initialization
    private void OnLevelWasLoaded(int level)
    {
        if (GameController.control.elitesSlain > 0)
        {
            oof.SetActive(true);
            for (int i = 0; i < GameController.control.elitesSlain; i++)
            {
                unlock();
            }
            GameController.control.elitesSlain = 0;
            pos = 0;
            foreach (bool b in GameController.control.unlockedCards)
            {
                if (b == true) pos++;
            }
            if (pos == 30) SceneManager.LoadScene("Victory");
        }


    }




    private void unlock()
    {
        foreach (bool b in GameController.control.unlockedCards)
        {
            if (b == true) pos++;
        }
        Debug.Log(pos);
        int pos2 = pos % 3 * 10;
        pos = (pos) / 3;

        if (pos2 + pos < 30)
        {
            GameController.control.unlockedCards[(int) (pos2 + pos)] = true;
            Debug.Log(pos2 + pos + "card was unlocked");
        }

        pos = 0;
    }
}
