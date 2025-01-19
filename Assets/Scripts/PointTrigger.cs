using System;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    public static Action OnScored;
    
    private const string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(PLAYER_TAG))
            return;
        
        OnScored?.Invoke();
    }
}
