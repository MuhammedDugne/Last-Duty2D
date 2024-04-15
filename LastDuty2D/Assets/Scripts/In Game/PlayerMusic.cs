using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
    public AudioSource  gunsVoice;
    public AudioClip[]  guns;

    private GameObject  soldierObject;
    private Rigidbody2D   soldierRb;
    private Fire        activeGuns;
    void Start()
    {
        soldierObject = GameObject.Find("Soldier");
        soldierRb = soldierObject.GetComponent<Rigidbody2D>();
        activeGuns = soldierRb.GetComponent<Fire>();
        gunsVoice.clip = guns[activeGuns.getGunsIndex()];
    }

    public void playGunsVoice()
    {
        gunsVoice.volume = PlayerPrefs.GetFloat("game");
        gunsVoice.clip = guns[activeGuns.getGunsIndex()];
        gunsVoice.Play();
    }

    public void stopSelectedVoice()
    {
        gunsVoice.Stop();
    }
}
