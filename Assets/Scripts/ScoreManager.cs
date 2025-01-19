using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private int score;
    
    private int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    private int bestScore;

    private int BestScore
    {
        get => bestScore;
        set
        {
            bestScore = value;
            bestScoreText.text = $"Najlepszy wynik: {bestScore.ToString()}";
        }
    }

    private void OnEnable()
    {
        PointTrigger.OnScored += UpdateScore;
        BirdController.OnLost += Reset;
    }

    private void OnDisable()
    {
        PointTrigger.OnScored -= UpdateScore;
        BirdController.OnLost -= Reset;
    }
    
    private void Reset()
    {
        Score = 0;
    }

    private void UpdateScore()
    {
        Score += 5;

        if (score <= bestScore) 
            return;
        
        BestScore = score;
    }
}
