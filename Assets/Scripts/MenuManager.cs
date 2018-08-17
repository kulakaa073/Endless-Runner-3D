using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Button StartButton;
	public Button ExitButton;

	// Use this for initialization
	void Start () {
		StartButton.onClick.AddListener (StartGame);
		ExitButton.onClick.AddListener (Exit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Exit()
	{
		Application.Quit ();
	}

	void StartGame()
	{
		SceneManager.LoadScene ("Scenes/Level");
	}
}
