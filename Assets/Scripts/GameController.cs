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

    public void Lose()
    {
        gameState = GameState.Menu;
        startingPanel.SetActive(true);
        spawner.SetActive(false);
        
    }
    
}
