using UnityEngine;

public static class ScoreSaver
{
    private const string BEST_SCORE_KEY = "bestScore";

    public static void Save(int score)
    {
        PlayerPrefs.SetInt(BEST_SCORE_KEY, score);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
    }
}
