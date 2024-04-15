using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider menuValue;
    public Slider gameValue;
    // Start is called before the first frame update
    void Start()
    {
        menuValue.value = PlayerPrefs.GetFloat("menu");
        gameValue.value = PlayerPrefs.GetFloat("game");
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("menu", menuValue.value);
        PlayerPrefs.SetFloat("game", gameValue.value);
        PlayerPrefs.Save();
    }
}
