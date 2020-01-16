using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    Text scoreBoard;
    int score;

    public void Awake()
    {
        scoreBoard = FindObjectsOfType<Text>()
            .FirstOrDefault(go => go.name.Equals("scoreBoard"));

        setScoreText();
    }

    public void AddScore(int scoreIncrement)
    {
        score += scoreIncrement;
        setScoreText();
    }

    private void setScoreText()
    {
        var textScore = string.Format("{0:D10}", score);
        scoreBoard.text = textScore;
    }
}
