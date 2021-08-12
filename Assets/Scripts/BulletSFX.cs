using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void ShootSFX()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
