using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public int playerScore {get; private set;}
    public TMP_Text playerScoreText;
    public int highScore {get; private set;}
    public TMP_Text highScoreText;
    public TMP_Text playerLivesText;
    public GameObject gameOverScreen;
    public GameObject newScoreText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        playerPaddle.input = true;
        gameOverScreen.SetActive(false);
        newScoreText.SetActive(false);
        playerPaddle.ResetLives();
        playerLivesText.text = Paddle.lives.ToString();
        SetPlayerScore(0);
        StartRound();
    }    

    public void StartRound()
    {        
        playerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void GameOver()
    {
        playerPaddle.input = false;
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
            SaveHighScore();
            newScoreText.SetActive(true);
        }
        gameOverScreen.SetActive(true);
    }

    public void PlayerScores(int score)
    {
        SetPlayerScore(this.playerScore + score);
    }

    public void LoseLife()
    {
        playerPaddle.DecrementLives();
        playerLivesText.text = Paddle.lives.ToString();
        if (Paddle.lives > 0)
        {            
            StartRound();
        }
        else
            GameOver();
    }

    private void SetPlayerScore(int score)
    {
        this.playerScore = score;
        this.playerScoreText.text = score.ToString();
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
}
