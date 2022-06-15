using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private TMP_Text gameOverScoreText;
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

    public void Continue()
    {
        gameObject.SetActive(false);
        player.SetActive(true);
        player.transform.position = playerStartPosition;
        player.transform.Rotate(Vector3.zero);
        asteroidSpawner.enabled = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
