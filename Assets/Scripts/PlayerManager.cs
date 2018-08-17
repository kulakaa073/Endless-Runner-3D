using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	// Controll keys
	public KeyCode MoveL;
	public KeyCode MoveR;

	// Player Speed modifiers
	public static int initVelocity;
	public static float speedModifier;

	// Horisontal movement
	public float horizVel;
	public int lane; //check for allowed line

	public bool isLocked = false; // Input restriction during movement

	// Player health
	public static int health;

	// Initial settings
	void Start () {
		initVelocity = 3;
		speedModifier = 1;

		horizVel = 0;
		lane = 2;

		health = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// Set Player velocity
		GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, initVelocity * speedModifier);
		speedModifier = 1 + GameManager.time / 5; // modifier for incresing player's speed over time

		// Control handlers
		if ((Input.GetKeyDown (MoveL)) && (lane > 1) && (!isLocked)) {
			isLocked = true; // lock player's controll
			horizVel = -5; // set horisontal speed
			StartCoroutine (StopSlide ()); // start routine to reset speed after certain point is reached
			lane -= 1; // switch player's line
		}

		if ((Input.GetKeyDown (MoveR)) && (lane < 3) && (!isLocked)) {
			isLocked = true;
			horizVel = 5;
			StartCoroutine (StopSlide ());
			lane += 1;
		}
	}

	// Triggers handlers
	void OnTriggerEnter(Collider other)
	{
		// Collided with "lethal" object:
		// Reduce player's health and "kill" if "damage is "lethal".
		// Note: "pits" instakill
		if (other.gameObject.tag == "lethal") {
			health -= 1;
			if ((health < 1) || (other.gameObject.name == "PitTrigger")) {
				Destroy (gameObject);
				SceneManager.LoadScene ("Scenes/ScoreScreen");
			}
			Destroy (other.gameObject);
		}

		// Collided with "coin"
		// Add bonus Score
		if (other.gameObject.tag == "coin") {
			Destroy (other.gameObject);
			GameManager.score += 100;
			GameManager.coins += 1;
		}

		// Collided with "pill"
		// Add health for the player
		if (other.gameObject.tag == "pill") {
			Destroy (other.gameObject);
			health += 1;
		}
	}

	// Reset horisontal speed and unlock player controll after delay
	IEnumerator StopSlide()
	{
		yield return new WaitForSeconds (.2f);
		horizVel = 0;
		isLocked = false;
	}
}
