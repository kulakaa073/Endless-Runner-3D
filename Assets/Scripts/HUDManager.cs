using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

	// Text labels to print out player's stats
	public TextMesh ScoreLabel;
	public TextMesh CoinLabel;
	public TextMesh TimeLabel;
	public TextMesh HealthLabel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ScoreLabel.GetComponent<TextMesh> ().text = "Score : " + GameManager.score;
		CoinLabel.GetComponent<TextMesh> ().text = "Coins : " + GameManager.coins;
		TimeLabel.GetComponent<TextMesh> ().text = "Time : " + Mathf.FloorToInt (GameManager.time);
		HealthLabel.GetComponent<TextMesh> ().text = "Health : " + PlayerManager.health;
	}
}
