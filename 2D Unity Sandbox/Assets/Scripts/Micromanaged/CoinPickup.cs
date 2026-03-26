using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public class CoinCollectedData
    {
        public string collectedByTag;
    }

    public delegate void OnCoinCollected(CoinCollectedData data);
    public static event OnCoinCollected CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       CoinCollectedData data = new CoinCollectedData();
       data.collectedByTag = collision.tag;
       CoinCollected?.Invoke(data);
       Destroy(gameObject);
    }
}