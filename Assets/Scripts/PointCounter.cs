using System;
using System.Collections;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public static Action OnScored;
    
    private Coroutine timerCoroutine;
    private bool isTimerRunning;
    
    public void StartCounting()
    {
        if (isTimerRunning)
            return;
        timerCoroutine = StartCoroutine(TimerCoroutine());
        isTimerRunning = true;
    }

    public void StopCounting()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
        
        isTimerRunning = false;
    }
    
    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            OnScored?.Invoke();
            yield return new WaitForSeconds(1f); 
        }
    }
}
