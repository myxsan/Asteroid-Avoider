using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private Button continueButton;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] GameObject player;

    private Vector3 playerStartPosition;

    private void Start()
    {
        playerStartPosition = player.transform.position;
        this.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);

        int finalScore = scoreSystem.EndTimer();
        gameOverScoreText.text = $"Score = {finalScore}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        asteroidSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
