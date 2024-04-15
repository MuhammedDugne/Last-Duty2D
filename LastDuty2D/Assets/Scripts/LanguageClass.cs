using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LanguageClass : MonoBehaviour
{
    [SerializeField] private TextAsset currentText;
    [SerializeField] private TextAsset[] languages;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI settingsText;
    [SerializeField] private TextMeshProUGUI trainingText;
    [SerializeField] private TextMeshProUGUI quitText;
    [SerializeField] private TextMeshProUGUI langText;
    [SerializeField] private TextMeshProUGUI menuVoiceText;
    [SerializeField] private TextMeshProUGUI gameVoiceText;
    [SerializeField] private TextMeshProUGUI mainMenuText;
    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private TextMeshProUGUI menuText;
    [SerializeField] private TextMeshProUGUI quitText2;
    void Start()
    {
        currentText = languages[PlayerPrefs.GetInt("language")];
        LanguageData data = new LanguageData();
        data = JsonUtility.FromJson<LanguageData>(currentText.text);
        UpdateDisplay(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLanguage()
    {
        currentText = languages[PlayerPrefs.GetInt("language")];
        LanguageData data = new LanguageData();
        data = JsonUtility.FromJson<LanguageData>(currentText.text);
        UpdateDisplay(data);
    }

    private void UpdateDisplay (LanguageData data)
    {
        if (playText != null)
            playText.text = data.playbutton;
        if (settingsText != null)
            settingsText.text = data.settingsbutton;
        if (trainingText != null)
            trainingText.text = data.trainingbutton;
        if (quitText != null)
            quitText.text = data.quitbutton;
        if (langText != null)
            langText.text = data.langbutton;
        if (menuVoiceText != null)
            menuVoiceText.text = data.menuvoice;
        if (gameVoiceText != null)
            gameVoiceText.text = data.gamevoice;
        if (mainMenuText != null)
            mainMenuText.text = data.menubutton;
        if (restartText != null)
            restartText.text = data.restart;
        if (volumeText != null)
            volumeText.text = data.volume;
        if (menuText != null)
            menuText.text = data.mainmenu;
        if (quitText2 != null)
            quitText2.text = data.quit;
    }

}
public class LanguageData
{
    public string playbutton;
    public string settingsbutton;
    public string trainingbutton;
    public string quitbutton;
    public string langbutton;
    public string menuvoice;
    public string gamevoice;
    public string menubutton;
    public string restart;
    public string volume;
    public string mainmenu;
    public string quit;
}
