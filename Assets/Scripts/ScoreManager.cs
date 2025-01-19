using TMPro;
using UnityEngine;
using Utility;

public class ScoreManager : MonoBehaviour
{
    private const string BEST_SCORE_KEY = "bestScore";
    
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
            SaveScore(value);
            bestScore = value;
            bestScoreText.text = $"Najlepszy wynik: {bestScore.ToString()}";
        }
    }

    private void OnEnable()
    {
        BestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
        
        PointCounter.OnScored += UpdateScore;
        BirdController.OnLost += Reset;
    }

    private void OnDisable()
    {
        PointCounter.OnScored -= UpdateScore;
        BirdController.OnLost -= Reset;
    }
    
    private void Reset()
    {
        Score = 0;
    }

    private void UpdateScore()
    {
        Score += 1;

        CheckDivisibility(score);
        if (score <= bestScore) 
            return;
        
        BestScore = score;
    }

    private static void CheckDivisibility(float score)
    {
        if (score % 10 != 0)
            return;
        
        GameController.Instance.BumpSpeed();
    }
    
    private void SaveScore(int value)
    {
        Debug.Log(value);
        PlayerPrefs.SetInt(BEST_SCORE_KEY, value);
    }
}
