using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        CoinPickup.CoinCollected += AddScore;
        EnemyChase.PlayerLoseCoin += LoseCoin;
    }

    private void OnDisable()
    {
        CoinPickup.CoinCollected -= AddScore;
        EnemyChase.PlayerLoseCoin -= LoseCoin;
    }

    void AddScore(CoinPickup.CoinCollectedData data)
    {
        if (data.collectedByTag == "Player") {
            score++;
            UpdateScoreText();
        }   
    }

    void LoseCoin()
    {
        score--;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
