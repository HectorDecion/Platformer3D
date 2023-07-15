using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    private float currentTime;
   // RangeAttribute[1,2,3]
    public float countdownTime = 5f;
 //   public TMPro.TextMeshPro timertext;
    private bool isTimerRunning = false;
    void Start()
    {
        StartTimer();
   //     timertext = GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                StopTimer();
                Debug.Log("Timer Termino");
                // Haz perdido. Tu tiempo termino.
                CanvasUIManager.sharedInstance.MostrarMuerto();


            }
        }
        

    }

    void StartTimer()
    {
        currentTime = countdownTime;
        isTimerRunning = true;
    }

    void StopTimer()
    {
        isTimerRunning = false;
    }
}
