using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameVolume : MonoBehaviour
{
    public Slider inGame;
    string currentScene = "";
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        inGame.value = PlayerPrefs.GetFloat("game");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene != "Main Menu" && currentScene != "Setting Menu"
            && currentScene != "Training Menu")
        {
            PlayerPrefs.SetFloat("game", inGame.value);
        }
    }
}
