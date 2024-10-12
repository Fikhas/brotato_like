using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Wave;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem Instance;

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameoverPanel;
    [SerializeField]
    private GameObject gameComplatePanel;

    private void Awake()
    {
        Instance = this;
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        gameComplatePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        GameManager.Instance.gameState = GameState.Pause;
        pausePanel.SetActive(true);
    }

    public void GameComplete()
    {
        GameManager.Instance.gameState = GameState.GameComplete;
        gameComplatePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.Instance.gameState = GameState.Gameplay;
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        gameComplatePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        CharController.Instance.ResetPlayerState();
        XPSystem.Instance.ResetXP();
        WaveManager.Instance.ResetWave();
        SceneManager.LoadScene(activeScene.name);
        GameManager.Instance.gameState = GameState.Gameplay;
    }

    public void BackToMenu()
    {
        gameoverPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameComplatePanel.SetActive(false);
        CharController.Instance.ResetPlayerState();
        XPSystem.Instance.ResetXP();
        WaveManager.Instance.ResetWave();
        SceneManager.LoadScene("TitleScreen");
    }

    public void Gameover()
    {
        GameManager.Instance.gameState = GameState.Gameover;
        gameoverPanel.SetActive(true);
    }
}
