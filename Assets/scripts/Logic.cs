using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Logic : MonoBehaviour
{
    public float totalHealth = 100f;
    private float enemyActivationTime;
    public float timeLimit = 10f;
    public GameObject GameOverScreen;   

    public GameObject bird;  
    public GameObject birdWing;  
    private Animator wing__flap;
    public GameObject EnemyBirdBoss;
    public GameObject HealthBarContainer;
    public Image healthBar;
    public GameObject pipeSpawner;
    public GameObject triggerSpawner;
    public Text scoreText;
    public Text HighScoreText;
    public int playerCurrentScore;
    private bool enemyActive = false;

    void Start()
    {
        wing__flap = birdWing.GetComponent<Animator>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) 
    {
        if (bird.GetComponent<BirdScript>().isAlive == true)
        {
            playerCurrentScore += scoreToAdd;
            scoreText.text = playerCurrentScore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        wing__flap.enabled = false;
        GameOverScreen.SetActive(true);
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (playerCurrentScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", playerCurrentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", playerCurrentScore);
        }

        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void DeleteHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.DeleteKey("HighScore");
            HighScoreText.text = 0.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", playerCurrentScore);
        }
    }
    
    private void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 1)
        {
            float theHighScore = PlayerPrefs.GetInt("HighScore");
            Debug.Log(theHighScore);
            if (playerCurrentScore >= theHighScore)
            {
                pipeSpawner.SetActive(false);
                triggerSpawner.SetActive(true);

                if (!enemyActive && !EnemyBirdBoss.activeSelf)
                {
                    EnemyBirdBoss.SetActive(true);
                    HealthBarContainer.SetActive(true);
                    enemyActivationTime = Time.time;
                    enemyActive = true;
                    Debug.Log("Enemy activated at: " + enemyActivationTime);
                }

                if (enemyActive)
                {
                    float elapsedTime = Time.time - enemyActivationTime;
                    Debug.Log("Elapsed time since enemy activation: " + elapsedTime);

                    if (elapsedTime >= timeLimit && totalHealth > 0)
                    {
                        HighScoreUpdate();
                        Debug.Log(Time.time + " - Game Over");
                        gameOver();
                        bird.GetComponent<BirdScript>().isAlive = false;
                    }
                }
            }

            if (playerCurrentScore == 8) {
                triggerSpawner.SetActive(false);
                pipeSpawner.SetActive(true);
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        totalHealth -= Damage;
        healthBar.fillAmount = totalHealth / 100f;
        Debug.Log("Damage taken. Current health: " + totalHealth);

        if (totalHealth <= 0)
        {
            totalHealth = 0; // Ensure health doesn't go below zero
            EnemyBirdBoss.SetActive(false);
            HealthBarContainer.SetActive(false);
            pipeSpawner.SetActive(true);
            enemyActive = false; // Enemy is no longer active
            Debug.Log("Enemy defeated");
        }
    }
}
