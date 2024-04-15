using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkinVoice : MonoBehaviour
{
    public AudioSource  walking;
    public AudioClip    walkingVoice;
    private GameObject  soldierObject;
    private Rigidbody2D   soldierRb;
    private CharacterMovement    walkingF;
    private bool isFirst = false;
    // Start is called before the first frame update
    void Start()
    {
        soldierObject = GameObject.Find("Soldier");
        soldierRb = soldierObject.GetComponent<Rigidbody2D>();
        walkingF = soldierRb.GetComponent<CharacterMovement>();
        walking.clip = walkingVoice;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingF.amIwalk == true)
        {
            if (isFirst == false)
            {
                isFirst = true;
                walking.volume = PlayerPrefs.GetFloat("game");
                walking.Play();
            }
        }
        else
        {
            isFirst = false;
            walking.Stop();
        }
    }
}
