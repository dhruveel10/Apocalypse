using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float restoreIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreIntensity(restoreIntensity);
            Destroy(gameObject);
        }
    }
}
