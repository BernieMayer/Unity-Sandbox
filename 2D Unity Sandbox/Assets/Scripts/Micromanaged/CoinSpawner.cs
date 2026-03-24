using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 8f;
    public float spawnRangeY = 4f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}