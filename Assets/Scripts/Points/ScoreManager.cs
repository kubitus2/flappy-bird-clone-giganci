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
        BestScore = ScoreSaver.GetScore();

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
        CheckBestScore();
    }

    private void CheckBestScore()
    {
        if (score <= bestScore)
            return;

        BestScore = score;
        ScoreSaver.Save(score);
    }

    private static void CheckDivisibility(float score)
    {
        if (score % 10 != 0)
            return;

        GameController.Instance.BumpSpeed();
    }
}