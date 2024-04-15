using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVoice : MonoBehaviour
{
    public AudioSource door;
    public AudioClip doorVoice;
    private float second = 0;
    // Start is called before the first frame update
    void Start()
    {
        door.clip = doorVoice;
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        door.volume = PlayerPrefs.GetFloat("game");
        if (second >= 2.0f)
        {
            door.Play();
            second = 0;
        }
    }
}
