using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	public KeyCode MoveL;
	public KeyCode MoveR;

	public float horizVel = 0;
	public int lane = 2;

	public bool isLocked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, GameManager.initVelocity * GameManager.speedModifier);

	if ((Input.GetKeyDown (MoveL)) && (lane > 1) && (!isLocked)) {
			isLocked = true;
			horizVel = -2;
			StartCoroutine (StopSlide ());
			lane -= 1;
		}

		if ((Input.GetKeyDown (MoveR)) && (lane < 3) && (!isLocked)) {
			isLocked = true;
			horizVel = 2;
			StartCoroutine (StopSlide ());
			lane += 1;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "lethal") {
			Destroy (gameObject);
			SceneManager.LoadScene ("Scenes/ScoreScreen");
		}

		if (other.gameObject.name == "Coin")
			Destroy (other.gameObject);
	}

	IEnumerator StopSlide()
	{
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		isLocked = false;
	}
}
