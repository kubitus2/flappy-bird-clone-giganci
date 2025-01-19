using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private BirdController player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject startingPanel;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        spawner.SetActive(false);
    }

    private void OnEnable()
    {
        StartingPanel.OnStartGame += StartGame;
        BirdController.OnLost += Lose;
    }

    private void StartGame()
    {
        startingPanel.SetActive(false);
        spawner.SetActive(true);
        player.StartGame();
        audioManager.PlayMusic();
    }

    private void Lose()
    {
        startingPanel.SetActive(true);
        RemoveObstacles();
        spawner.SetActive(false);
        audioManager.StopMusic();
    }

    private void RemoveObstacles()
    {
        var t = spawner.transform;
        for (var i = 0; i < t.childCount; i++)
        {
            var child = t.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}
