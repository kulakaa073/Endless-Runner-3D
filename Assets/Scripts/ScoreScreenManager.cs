using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreenManager : MonoBehaviour {

	// Menu buttons
	public Button RestartButton;
	public Button MainMenuButton;

	// Final players stats
	public Text ScoreLabel;
	public Text CoinLabel;
	public Text TimeLabel;

	// Add listeners to buttons amd call needed vunctions
	void Start () {
		RestartButton.onClick.AddListener (Restart);
		MainMenuButton.onClick.AddListener (MainMenu);
	}

	// Update Players stats
	void Update () {
		ScoreLabel.GetComponent<Text> ().text = "Score : " + GameManager.score;
		CoinLabel.GetComponent<Text> ().text = "Coins : " + GameManager.coins;
		TimeLabel.GetComponent<Text> ().text = "Time : " + Mathf.FloorToInt (GameManager.time);
	}

	// MainMenuButton was pressed
	// Load Main menu scene
	void MainMenu()
	{
		SceneManager.LoadScene ("Scenes/MainMenu");
	}

	// RestartButton was pressed
	// Load game
	void Restart()
	{
		SceneManager.LoadScene ("Scenes/Level");
	}
}
