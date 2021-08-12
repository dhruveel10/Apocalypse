using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;
    [SerializeField] TextMeshProUGUI healthText;
   
    // Start is called before the first frame update
    void Start()
    {
        impactCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSpatter());
    }

    IEnumerator ShowSpatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }

}
