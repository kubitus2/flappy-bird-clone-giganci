using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnRate = 4f;
    [SerializeField] private float spawnHeight = 2f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0f) 
            return;
        
        Spawn();
        timer = spawnRate;
    }

    private void Spawn()
    {
        var randomIndex = Random.Range(0, obstacles.Length);
        var randomY = Random.Range(-spawnHeight, spawnHeight);
        var spawnPosition = transform.position + Vector3.up * randomY;
        
        Instantiate(obstacles[randomIndex], spawnPosition, Quaternion.identity, transform);
    }
}
