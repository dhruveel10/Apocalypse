using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip shootClip;
    private AudioSource audioManager;
    private GameObject shootImpact;

    // Start is called before the first frame update
    void Awake()
    {
        shootImpact = transform.Find("ShootImpact").gameObject;
        shootImpact.SetActive(false);

        audioManager = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        audioManager.Play();
        StartCoroutine(TurnShootImpactOn());
    }

    IEnumerator TurnShootImpactOn()
    {
        shootImpact.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        shootImpact.SetActive(false);
    }
}
