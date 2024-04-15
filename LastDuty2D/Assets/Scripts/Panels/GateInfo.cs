using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateInfo : MonoBehaviour
{
    [Multiline] private string currentText;
    [Multiline] public string trText;
    [Multiline] public string engText;
    private TextMeshProUGUI slowText;
    private float delay = 0.1f;
    private ShakeCamera shake;
    private EnemyController boss;
    private int lang;
    private bool gateOpen = false;
    public AudioSource message;
    public AudioClip messageVoice;
    void Start()
    {
        slowText = GetComponent<TextMeshProUGUI>();
        GameObject cam = GameObject.FindWithTag("Virtual");
        Rigidbody2D camRb = cam.GetComponent<Rigidbody2D>();
        shake = camRb.GetComponent<ShakeCamera>();
        GameObject bossObj = GameObject.Find("boss");
        Rigidbody2D rbBoss = bossObj.GetComponent<Rigidbody2D>();
        boss = rbBoss.GetComponent<EnemyController>();
        if (PlayerPrefs.GetInt("language") == 0)
            currentText = trText;
        else
            currentText = engText;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.isDeadBoss == true && shake.getisShaking() == false && gateOpen == false)
        {
            gateOpen = true;
            message.clip = messageVoice;
            message.Play();
            StartCoroutine(slowTexting());
        }
    }

    IEnumerator slowTexting()
    {
        foreach (char i in currentText)
        {
            slowText.text += i.ToString();
            yield return new WaitForSeconds(delay);
        }
        Destroy(gameObject, 3f);
    }
}
