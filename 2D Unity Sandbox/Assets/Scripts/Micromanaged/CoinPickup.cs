using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public delegate void OnCoinCollected();
    public static event OnCoinCollected CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}