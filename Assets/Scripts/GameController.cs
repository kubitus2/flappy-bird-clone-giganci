using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsPlaying { get; set; }

    [SerializeField] private BirdController player;

    public void Lose()
    {
        IsPlaying = false;
    }
    
}
