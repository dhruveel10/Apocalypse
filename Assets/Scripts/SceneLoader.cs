using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadLevelEasy()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void LoadLevelMedium()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
