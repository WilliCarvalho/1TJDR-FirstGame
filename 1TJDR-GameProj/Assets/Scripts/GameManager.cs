using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    public int score = 0;
    private void Awake()
    {
        instance = this;
        gameOverText.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void OnGameOnver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
