using System;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    Menu,
    Playing
}
public class GameController : MonoBehaviour
{
    private GameState gameState = GameState.Menu;

    [SerializeField] private BirdController player;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject startingPanel;

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
        gameState = GameState.Playing;
        startingPanel.SetActive(false);
        spawner.SetActive(true);
        player.StartGame();
    }

    private void Lose()
    {
        gameState = GameState.Menu;
        startingPanel.SetActive(true);
        RemoveObstacles();
        spawner.SetActive(false);
        
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
