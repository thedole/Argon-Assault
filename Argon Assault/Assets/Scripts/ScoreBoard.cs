using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    Text scoreBoard;

    public void Awake()
    {
        scoreBoard = FindObjectsOfType<Text>()
            .FirstOrDefault(go => go.name.Equals("scoreBoard"));

        setScore(0);
    }

    public void AddScore(int scoreIncrement)
    {
        var currentScore = int.Parse(scoreBoard.text);
        var newScore = currentScore + scoreIncrement;

        setScore(newScore);
    }

    private void setScore(int score)
    {
        var textScore = string.Format("{0:D10}", score);
        scoreBoard.text = textScore;
    }
}
