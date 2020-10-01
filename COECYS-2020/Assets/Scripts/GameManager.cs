using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float playerScore;
    public bool isGamePlaying;

    public GameObject finalPanel;
    public Text finalScoreText;
    public Text scoreText;


    public void StartGame()
    {
        playerScore = 0;
        isGamePlaying = true;
    }

    public void AddScore(float score)
    {
        playerScore += score;
        scoreText.text = "Score: " + playerScore;
    }

    public void FinishGame()
    {
        finalScoreText.text = "Your final score is " + playerScore;
        isGamePlaying = false;
        finalPanel.SetActive(true);
    }
}
