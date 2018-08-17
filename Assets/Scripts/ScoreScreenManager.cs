using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreenManager : MonoBehaviour {

	public Button RestartButton;
	public Button MainMenuButton;
	public Text ScoreLabel;
	public Text CoinLabel;

	// Use this for initialization
	void Start () {
		RestartButton.onClick.AddListener (Restart);
		MainMenuButton.onClick.AddListener (MainMenu);
		ScoreLabel.text = "Score : ";// + GameManager.score;
		CoinLabel.text = "Coins : ";// + GameManager.coins;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void MainMenu()
	{
		SceneManager.LoadScene ("Scenes/MainMenu");
	}

	void Restart()
	{
		SceneManager.LoadScene ("Scenes/Level");
	}
}
