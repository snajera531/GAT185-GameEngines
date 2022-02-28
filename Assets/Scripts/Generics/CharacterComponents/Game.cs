using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game : Singleton<Game>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER
	}

	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timeUI;
	[SerializeField] Slider healthUI;
	[SerializeField] ScreenFade screenFade;

	[SerializeField] AudioClip musicClip;

	public float health { set { healthUI.value = value; } }

	int score = 0;
	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = score.ToString("D2");
		}
	}

	int lives = 0;
	public int Lives
	{
		get { return lives; }
		set
		{
			lives = value;
			livesUI.text = lives.ToString();
		}
	}

	float gameTime = 0;
	public float GameTime
	{
		get { return gameTime; }
		set
		{
			gameTime = value;
			timeUI.text = "<mspace=mspace=36>" + gameTime.ToString("0.0") + "</mspace>";
		}
	}

	State state = State.TITLE;
	int highScore;

	private void Start()
	{
		highScore = PlayerPrefs.GetInt("highscore", 0);
		highScore++;
		PlayerPrefs.SetInt("highscore", highScore);
		print(highScore);

		//PlayerPrefs.DeleteAll();
		//PlayerPrefs.DeleteKey("highscore");

		AudioManager.Instance.PlayMusic(musicClip);
	}

	private void Update()
	{
		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				break;
			case State.GAME:
				break;
			case State.PLAYER_DEAD:
				break;
			case State.GAME_OVER:
				break;
			default:
				break;
		}
	}

	public void OnLoadScene(string sceneName)
    {
		StartCoroutine(LoadScene(sceneName));
    }

	IEnumerator LoadScene(string sceneName)
    {
		screenFade.FadeOut();
		yield return new WaitUntil(() => screenFade.IsDone);
		SceneManager.LoadScene(sceneName);
    }
}
