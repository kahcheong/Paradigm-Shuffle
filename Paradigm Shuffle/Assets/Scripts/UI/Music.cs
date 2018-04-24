using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{

    public AudioSource audio1;
    public AudioSource audio2;
    public AudioClip[] myMusic = new AudioClip[3];
    public int source = 1;
    private bool first = true;
    // Use this for initialization
    void Awake()
    {
        if (first)
        {
            audio1.clip = myMusic[0] as AudioClip;
            first = false;
        }
    }
    void Start()
    {

        audio1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio1.isPlaying)
            playRandomMusic();
    }
    public void playRandomMusic()
    {
        audio1.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio1.Play();
    }

    public void StopBoss()
    {
        StartCoroutine(AudioFadeOut.FadeOut(GameController.control.gameObject.GetComponent<Music>().audio2, 1f));
    }
}