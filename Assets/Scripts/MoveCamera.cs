using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update camera speed to match player's speed
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, PlayerManager.initVelocity * PlayerManager.speedModifier);
	}
}
