using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] Canvas gamePauseCanvas;

    private void Start()
    {
        gamePauseCanvas.enabled = false;
    }

    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        gamePauseCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        gamePauseCanvas.enabled = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
