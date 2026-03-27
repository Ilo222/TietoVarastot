using TMPro;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    private int score = 0;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highscore;
        UpdateScoreText();
    }

    public void Click()
    {
        score++;
        UpdateScoreText();
    }

    public void EndGame()  // ✅ tässä, luokan sisällä, muiden metodien ulkopuolella
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscoreText.text = "Highscore: " + score;
            Debug.Log("Uusi highscore: " + score);
        }

        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}