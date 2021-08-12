using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect; 
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetnShoots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    public AudioClip shootClip;
    private AudioSource audioManager;
    private GameObject shootImpact;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
    void Awake()
    {
        shootImpact = transform.Find("ShootImpact").gameObject;
        shootImpact.SetActive(false);

        audioManager = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            BulletImpact();
            StartCoroutine(Shoot());
        }
        DisplayAmmo();
    }
    public void BulletImpact()
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

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrAmmo(ammoType);
        ammoText.text = currentAmmo.ToString(); 
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrAmmo(ammoType) > 0)
        {
            PlayShootingVFX();
            ProcessRaycast();
            
            ammoSlot.ReduceCurrAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetnShoots);
        canShoot = true;
    }

    private void PlayShootingVFX()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            print(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
