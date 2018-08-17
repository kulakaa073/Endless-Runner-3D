using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Main menu buttons
	public Button StartButton;
	public Button ExitButton;

	// Add listeners
	void Start () {
		StartButton.onClick.AddListener (StartGame);
		ExitButton.onClick.AddListener (Exit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ExitButton was pressed
	// Closing game
	void Exit()
	{
		Application.Quit ();
	}

	// StartButton was pressed
	// Load game
	void StartGame()
	{
		SceneManager.LoadScene ("Scenes/Level");
	}
}
