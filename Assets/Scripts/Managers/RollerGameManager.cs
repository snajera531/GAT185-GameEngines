using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RollerGameManager : Singleton<RollerGameManager>
{
    enum State
    {
        TITLE,
        PLAYER_START,
        GAME,
        PLAYER_DEAD,
        GAME_OVER,
        WIN
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;
    [SerializeField] GameObject mainCamera;

    [SerializeField] Text livesUI;
    [SerializeField] Text scoreUI;
    [SerializeField] Text timeUI;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject winUI;

    public float PlayerHealth { set { healthSlider.value = value; } }

    public delegate void GameEvent();

    public event GameEvent startGameEvent;
    public event GameEvent stopGameEvent;

    int score = 0;
    int lives = 0;
    State state = State.TITLE;
    float stateTimer = 0;
    float gameTime = 0;
    int winningScore = 100;

    public float GameTime
    {
        get { return gameTime; }
        set
        {
            gameTime = value;
            timeUI.text = gameTime.ToString("0.0");
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

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreUI.text = score.ToString() + " / 5";
            OnPlayerWin();
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
                transform.position = playerSpawn.position;
                mainCamera.SetActive(false);
                startGameEvent?.Invoke();

                PlayerHealth = 200;
                GameTime = 60;

                state = State.GAME;
                break;
            case State.GAME:
                GameTime -= Time.deltaTime;
                if(GameTime <= 0)
                {
                    GameTime = 0;
                    state = State.GAME_OVER;
                    stateTimer = 5;
                }
                break;
            case State.PLAYER_DEAD:
                if (stateTimer <= 0)
                {
                    state = State.PLAYER_START;
                    mainCamera.SetActive(true);
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
            case State.WIN:
                if (stateTimer <= 0)
                {
                    state = State.TITLE;
                    winUI.SetActive(false);
                    titleScreen.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        state = State.PLAYER_START;
        Score = 0;
        Lives = 3;
        gameTime = 0;

        titleScreen.SetActive(false);
    }

    public void OnStartTitle()
    {
        state = State.TITLE;
        titleScreen.SetActive(true);
        stopGameEvent();
    }

    public void OnPlayerDeath(GameObject gameObject)
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

        stopGameEvent?.Invoke();
    }

    public void OnPlayerWin()
    {
        if(score == winningScore)
        {
            state = State.WIN;
            stateTimer = 5;
        }
    }
}

