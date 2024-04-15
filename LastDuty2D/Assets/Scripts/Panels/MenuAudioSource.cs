using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioSource : MonoBehaviour
{
    public AudioSource  menuSource;
    public AudioClip    menuMusic1;
    public AudioClip    menuMusic2;
    public AudioClip    menuMusic3;
    public AudioClip    menuMusic4;
    public AudioClip    menuMusic5;
    public AudioClip    menuMusic6;
    // Start is called before the first frame update
    void Start()
    {
        int whichMusic = Random.Range(1, 7);
        if (whichMusic == 1)
            menuSource.clip = menuMusic1;
        else if (whichMusic == 2)
            menuSource.clip = menuMusic2;
        else if (whichMusic == 3)
            menuSource.clip = menuMusic3;
        else if (whichMusic == 4)
            menuSource.clip = menuMusic4;
        else if (whichMusic == 5)
            menuSource.clip = menuMusic5;
        else if (whichMusic == 6)
            menuSource.clip = menuMusic6;
        menuSource.volume = PlayerPrefs.GetFloat("menu");
        menuSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        menuSource.volume = PlayerPrefs.GetFloat("menu");
    }
}
