using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicControl : MonoBehaviour
{
    private static MainMenuMusicControl instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene != "Setting Menu" && currentScene != "Training Menu"
               && currentScene != "Main Menu")
            Destroy(gameObject);
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene != "Setting Menu" && currentScene != "Training Menu"
               && currentScene != "Main Menu")
            Destroy(gameObject);
    }
}
