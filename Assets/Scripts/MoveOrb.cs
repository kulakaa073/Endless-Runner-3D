using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrb : MonoBehaviour {

	public KeyCode MoveL;
	public KeyCode MoveR;

	public float horizVel = 0;
	public int lane = 2;

	public bool isLocked = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (horizVel, 0, 4);

		if ((Input.GetKeyDown (MoveL)) && (lane > 1) && (isLocked)) {
			isLocked = false;
			horizVel = -2;
			StartCoroutine (StopSlide ());
			lane -= 1;
		}

		if ((Input.GetKeyDown (MoveR)) && (lane < 3) && (isLocked)) {
			isLocked = false;
			horizVel = 2;
			StartCoroutine (StopSlide ());
			lane += 1;
			print ("lane = " + lane);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "lethal")
			//Destroy (gameObject);
		if (other.gameObject.name == "Coin")
			Destroy (other.gameObject);
	}

	IEnumerator StopSlide()
	{
		yield return new WaitForSeconds (.5f);
		horizVel = 0;
		isLocked = true;
	}
}
