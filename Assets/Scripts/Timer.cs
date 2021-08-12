using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] Canvas timerCanvas;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] int secondsLeft = 60;
    public bool takingAway, timerOn = false;

    private void Start()
    {
        timerCanvas.enabled = false;
        timerText.text = secondsLeft.ToString();
        timerOn = false;
    }

    void Update()
    {
        if(timerOn == true)
        {
            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            }
            timerOn = true;
        }
        
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1f);
        secondsLeft -= 1;
        timerText.text = secondsLeft.ToString();
        takingAway = false;
      //  timerOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            timerCanvas.enabled = true;
            timerOn = true;
        }

    }
}
