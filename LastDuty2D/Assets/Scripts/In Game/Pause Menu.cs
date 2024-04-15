using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Restart()
    {
        string  currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
