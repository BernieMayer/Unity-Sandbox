using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public CircleCollider2D circleCollider;
    public float speed = 2f;

    public delegate void OnPlayerLoseCoin();
    public static event OnPlayerLoseCoin PlayerLoseCoin;

    private void OnEnable()
    {
        CoinPickup.CoinCollected += IncreaseSize;
    }
    private void OnDisable()
    {
        CoinPickup.CoinCollected -= IncreaseSize;
    }

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }


    void IncreaseSize(CoinPickup.CoinCollectedData data) 
    {
        if (data.collectedByTag == "Enemy")
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            circleCollider.radius = circleCollider.radius * 1.1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          PlayerLoseCoin?.Invoke();
        }
    }
}