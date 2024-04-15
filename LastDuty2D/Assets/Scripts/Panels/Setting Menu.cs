using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject mainPanel;
    public int subtitle;
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("language"))
            subtitle = 0;
        else
            subtitle = PlayerPrefs.GetInt("language");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MainMenu()
    {
        settingPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void tickSub()
    {
        subtitle = ((subtitle + 1) % 2);
        PlayerPrefs.SetInt("language", subtitle);
        GameObject langObj = GameObject.Find("LanguageKit");
        Rigidbody2D rbLang = langObj.GetComponent<Rigidbody2D>();
        LanguageClass langSc = rbLang.GetComponent<LanguageClass>();
        langSc.ChangeLanguage();
    }
}
