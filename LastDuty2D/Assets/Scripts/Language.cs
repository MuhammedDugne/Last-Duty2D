using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public int language;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("language"))
            language = PlayerPrefs.GetInt("language");
        else
        {
            language = 0;
            PlayerPrefs.SetInt("language", language);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
