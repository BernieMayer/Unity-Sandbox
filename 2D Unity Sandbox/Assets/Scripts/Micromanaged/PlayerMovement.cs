using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;

    private void OnEnable()
    {
        CoinPickup.CoinCollected += IncreaseSpeed;
    }

    private void OnDisable()
    {
        CoinPickup.CoinCollected -= IncreaseSpeed;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void IncreaseSpeed(CoinPickup.CoinCollectedData data)
    {
        if (data.collectedByTag == "Player") 
        {
            moveSpeed += 0.1f;
            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }
    
    }
}