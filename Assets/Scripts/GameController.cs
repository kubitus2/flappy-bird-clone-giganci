using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Speed")] 
    [SerializeField] private float startSpeed = 1.2f;
    [SerializeField] private float speedIncrement = 0.3f;

    [Header("Controllers")] 
    [SerializeField] private BirdController player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject startingPanel;
    [SerializeField] private PointCounter pointCounter;
    [SerializeField] private AudioManager audioManager;

    public float Velocity { get; private set; }
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        spawner.SetActive(false);
    }

    private void OnEnable()
    {
        StartingPanel.OnStartGame += StartGame;
        BirdController.OnLost += Lose;
    }

    private void StartGame()
    {
        Velocity = 1.2f;
        startingPanel.SetActive(false);
        spawner.SetActive(true);
        player.StartGame();
        audioManager.PlayMusic();
        pointCounter.StartCounting();
    }

    public void BumpSpeed()
    {
        Velocity += speedIncrement;
    }

    private void Lose()
    {
        startingPanel.SetActive(true);
        RemoveObstacles();
        spawner.SetActive(false);
        audioManager.StopMusic();
        pointCounter.StopCounting();
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