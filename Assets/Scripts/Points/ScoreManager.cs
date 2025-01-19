using TMPro;
using UnityEngine;
using Utility;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int accelerateEveryNthPoint = 10;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private int _score;

    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
    }

    private int _bestScore;

    private int BestScore
    {
        get => _bestScore;
        set
        {
            _bestScore = value;
            bestScoreText.text = $"Najlepszy wynik: {_bestScore.ToString()}";
        }
    }

    private void OnEnable()
    {
        BestScore = ScoreSaver.GetScore();
    }

    public void Reset()
    {
        Score = 0;
    }

    public void UpdateScore()
    {
        Score += 1;

        CheckDivisibility(_score);
        CheckBestScore();
    }

    private void CheckBestScore()
    {
        if (_score <= _bestScore)
            return;

        BestScore = _score;
        ScoreSaver.Save(_score);
    }

    private void CheckDivisibility(int score)
    {
        if (!score.CheckDivisibility(accelerateEveryNthPoint))
            return;

        GameController.Instance.BumpSpeed();
    }
}