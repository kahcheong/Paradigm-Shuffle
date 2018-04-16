using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour {
    public Text textBox;
    public string inputText;
    //Store all your text in this string array
    string[] goatText = new string[] { "Oh dear...\n Seems you've died again.\n I'll raise you again, but try a little harder this time." };

    int currentlyDisplayingText = 0;
    void Awake()
    {
        StartCoroutine(AnimateText());
    }
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText > goatText.Length)
        {
            currentlyDisplayingText = 0;
        }
        StartCoroutine(AnimateText());
    }
    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (goatText[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = goatText[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
    }
}
