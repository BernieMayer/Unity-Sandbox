using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        CoinPickup.CoinCollected += AddScore;
    }

    private void OnDisable()
    {
        CoinPickup.CoinCollected -= AddScore;
    }

    void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
