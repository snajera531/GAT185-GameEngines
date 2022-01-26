using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    enum State
    {
        TITLE,
        GAME
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;
    [SerializeField] GameObject titleScreen;
    [SerializeField] Text scoreUI;
    [SerializeField] Text livesUI;
    [SerializeField] Slider healthSlider;

    public float PlayerHealth { set { healthSlider.value = value; } }

    public delegate void GameEvent();

    public event GameEvent startGameEvent;
    public event GameEvent stopGameEvent;

    int score = 0;
    int lives = 0;
    State state = State.TITLE;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreUI.text = score.ToString();
        }
    }

    public int Lives
    {
        get { return score; }
        set
        {
            score = value;
            scoreUI.text = score.ToString();
        }
    }

    public void OnStartGame()
    {
        state = State.GAME;
        Score = 0;
        Lives = 3;

        titleScreen.SetActive(false);

        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        startGameEvent?.Invoke();
    }

    public void OnStartTitle()
    {
        state = State.TITLE;
        titleScreen.SetActive(true);
        stopGameEvent();
    }

    public void OnPlayerDeath()
    {
        //if(lives <= 0)
        //      {

        //      }
        //      else
        {
            Lives--;
            livesUI.text = "LIVES: " + Lives;
            Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        }
    }
}
