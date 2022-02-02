using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RollerGameManager : Singleton<GameManager>
{
    enum State
    {
        TITLE,
        PLAYER_START,
        GAME,
        PLAYER_DEAD,
        GAME_OVER
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;
    [SerializeField] Text scoreUI;
    [SerializeField] Text livesUI;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverUI;

    public float PlayerHealth { set { healthSlider.value = value; } }

    public delegate void GameEvent();

    public event GameEvent startGameEvent;
    public event GameEvent stopGameEvent;

    int score = 0;
    int lives = 0;
    State state = State.TITLE;
    float stateTimer = 0;
    float gameTimer = 0;

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
        get { return lives; }
        set
        {
            lives = value;
            livesUI.text = "LIVES: " + lives.ToString();
        }
    }

    private void Update()
    {
        stateTimer -= Time.deltaTime;

        switch (state)
        {
            case State.TITLE:
                break;
            case State.PLAYER_START:
                //Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
                startGameEvent();

                state = State.GAME;
                break;
            case State.GAME:
                gameTimer += Time.deltaTime;
                if(gameTimer > 5)
                {
                    gameTimer = 5;
                }
                break;
            case State.PLAYER_DEAD:
                if (stateTimer <= 0)
                {
                    state = State.PLAYER_START;
                }
                break;
            case State.GAME_OVER:
                if (stateTimer <= 0)
                {
                    state = State.TITLE;
                    gameOverUI.SetActive(false);
                    titleScreen.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        state = State.PLAYER_START;
        Score = 0;
        Lives = 3;
        gameTimer = 0;

        titleScreen.SetActive(false);
    }

    public void OnStartTitle()
    {
        state = State.TITLE;
        titleScreen.SetActive(true);
        stopGameEvent();
    }

    public void OnPlayerDeath()
    {
        Lives--;

        if (Lives == 0)
        {
            state = State.GAME_OVER;
            stateTimer = 5;

            gameOverUI.SetActive(true);
        }
        else
        {
            state = State.PLAYER_DEAD;
            stateTimer = 3;
        }

        stopGameEvent();
    }
}

