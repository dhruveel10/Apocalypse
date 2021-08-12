using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 200f;
    [SerializeField] TextMeshProUGUI healthText;

    public AudioClip shootClip;
    private AudioSource audioManager;

    MusicPlayer deletePlayer;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
        deletePlayer = FindObjectOfType<MusicPlayer>();
        healthText.text = hitPoints.ToString();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        DisplayHealth();
        if(hitPoints <= 50)
        {
            audioManager.Play();
            deletePlayer.gameObject.SetActive(false);
            if (hitPoints <= 0)
            {
                GetComponent<DeathHandler>().HandleDeath();
            }
        }
        
    }

    private void DisplayHealth()
    {
        float getHealth = hitPoints;
        healthText.text = getHealth.ToString();
    }
}
