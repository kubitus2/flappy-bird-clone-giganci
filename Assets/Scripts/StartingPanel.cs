using System;
using UnityEngine;

public class StartingPanel : MonoBehaviour
{
    public static Action OnStartGame;
    
    private void Update()
    {
        if(Input.GetKeyDown("space"))
            OnStartGame?.Invoke();
            
    }
}
