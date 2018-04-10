using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This script is added to the text component of a UI element

public class UITextEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Text txtStart;
    public Color newColour;     //Remember to set the alpha!!
    public Color originalColour;
    public AudioSource sound;
    bool hasAudio = false;

    public string LoadLevel;

    void Start()
    {
        txtStart = GetComponent<Text>();
        originalColour = txtStart.color;

        sound = GetComponent<AudioSource>();

        if (sound)
        {
            hasAudio = true;
        }
        else
        {
            print("Object has no audio");
        }
    }

    public void OnPointerEnter(PointerEventData e)
    {
        txtStart.color = newColour;
        if (hasAudio)
            sound.Play();
    }

    public void OnPointerClick(PointerEventData e)
    {
        print("Load: " + LoadLevel);
        if (!String.IsNullOrEmpty(LoadLevel))
        {
            SceneManager.LoadScene(LoadLevel);
           
        }
    }

    public void OnPointerExit(PointerEventData e)
    {
        txtStart.color = originalColour;
        if (hasAudio)
            sound.Stop();
    }
}