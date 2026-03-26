using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 8f;
    public float spawnRangeY = 4f;
    public float spawnClearRadius = 0.5f;
    public int maxSpawnAttempts = 10;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomY = Random.Range(-spawnRangeY, spawnRangeY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            if (!IntersectsPlayerOrEnemy(spawnPosition))
            {
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }
    }

    bool IntersectsPlayerOrEnemy(Vector2 position)
    {
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(position, spawnClearRadius);
        foreach (Collider2D overlap in overlaps)
        {
            if (overlap.CompareTag("Player") || overlap.CompareTag("Enemy"))
            {
                return true;
            }
        }

        return false;
    }
}