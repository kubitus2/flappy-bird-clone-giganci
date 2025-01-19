using System;
using UnityEngine;

public class StartingPanel : MonoBehaviour
{
    public static Action OnStartGame;

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
