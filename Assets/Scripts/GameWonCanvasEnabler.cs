using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonCanvasEnabler : MonoBehaviour
{
    [SerializeField] Canvas gameWonCanvas;

    private void Start()
    {
        gameWonCanvas.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameWonCanvas.enabled = true;
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
