using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    
    private float _timer = 0f;
    private float gameDuration = 20f;

    public GameObject winPanel;
    public GameObject losePanel;

    public int score = 0;
    private int Score => score;

    [SerializeField] private int targetScore;
    
    
    private bool isGameEnd;
    private bool isGamePaused;
    private void Awake()
    {
        Instance = this;
    }

    public bool IsGameEnded()
    {
        return isGameEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameEnd && !isGamePaused)
        {
            _timer += Time.deltaTime;
            timerText.text = "Countdown: " + Mathf.FloorToInt(gameDuration - _timer).ToString();
            
            if (_timer >= gameDuration)
            {
                EndGame();
            }
        }
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    
    private void EndGame()
    {
        isGameEnd = true;
        if (score >= targetScore)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        winPanel.SetActive(true);
        PauseGame();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void LoseGame()
    {
        losePanel.SetActive(true);
        PauseGame();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
