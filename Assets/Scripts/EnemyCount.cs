using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyCount : MonoBehaviour
{
    [SerializeField] int enemiesLeft = 16;
    [SerializeField] TextMeshProUGUI enemyLeftText;

    [SerializeField] Canvas gameWonCanvas;

    bool killedAllEnemies = false;

    void Start()
    {
        enemiesLeft = 16;
        gameWonCanvas.enabled = false;
    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        int getEnemyCount = enemiesLeft;
        enemyLeftText.text = getEnemyCount.ToString();
            enemiesLeft--;
        if (enemiesLeft == 0)
        {
            endGame();
        }
    }

    void endGame()
    {
        killedAllEnemies = true;
        EnableGameOverCanvas();
    }

    void EnableGameOverCanvas()
    {
        if (killedAllEnemies)
        {
            HandleWin();
        }
        else
        {
            gameWonCanvas.enabled = false;
        }
    }

    public void HandleWin()
    {
        gameWonCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
