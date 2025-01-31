using System.Collections;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private Coroutine _timerCoroutine;
    private bool _isTimerRunning;

    public void StartCounting()
    {
        if (_isTimerRunning)
            return;
        _isTimerRunning = true;
        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopCounting()
    {
        _isTimerRunning = false;

        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);
    }

    private IEnumerator TimerCoroutine()
    {
        while (_isTimerRunning)
        {
            GameController.Instance.UpdateScore();
            yield return new WaitForSeconds(1f);
        }
    }
}