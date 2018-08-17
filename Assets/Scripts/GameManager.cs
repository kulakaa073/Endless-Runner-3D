using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tracking player's stats and handling environment building
public class GameManager : MonoBehaviour {

	// main player's stats
	public static int score;
	public static int coins;
	public static float time;

	//public static int highScore = 0; feature for future

	public GameObject player;

	public int worldPos; // keeping track on z axis of next object placement

	// Environment objects
	public GameObject roadClear;
	public GameObject roadPitM;
	public GameObject roadPitL;
	public GameObject roadPitR;

	public GameObject obstacle;
	public GameObject pill;
	public GameObject coin;

	// List of currently builded environment objects
	public List<GameObject> road;

	void Start () 
	{
		// Initial settings
		worldPos = 0;

		score = 0;
		coins = 0;
		time = 0;

		// Spawning stating free blocks
		SpawnObj (roadClear, true);
		SpawnObj (roadClear, true);
		SpawnObj (roadClear, true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Track time and score stats
		time += Time.deltaTime;
		score += Mathf.FloorToInt (time) / 10;

		// Check player z position 
		// Build next tile if player close enough to the end
		if (worldPos - player.transform.position.z < 80) {
			int randNum = Random.Range (0, 100); // roll for "pit"
			if (randNum < 30) { // "pit" success
				int randType = Random.Range (0, 100); // roll for "pit" type
				if (randType < 30) {
					SpawnObj (roadPitL, true);
				} else if (randType < 60) {
					SpawnObj (roadPitR, true);
				} else {
					SpawnObj (roadPitM, true);
				}
			} else {
				SpawnObj (roadClear, true); // "pit" roll failed, build clear road and check for items
				int randType = Random.Range (0, 100);
				if (randType < 25) {
					SpawnObj (obstacle, false);
				} else if (randType < 75) {
					SpawnObj (coin, false);
				} else {
					SpawnObj (pill, false);
				}
			}
		}

		// Check if objects in list is far enough behind player
		// Delete them to prevent leaks
		foreach (GameObject obj in road) {
			if (obj != null) { // check if object wasnt deleted yet
				if (player.transform.position.z - obj.transform.position.z > 20) {
					Destroy (obj);
					road.Remove (obj);
				}
			}
		}
	}

	// Generic spawing fuction
	void SpawnObj(GameObject gameObj, bool bRoad)
	{
		GameObject tmp; // temporal object to be able to keep track on currently builded objects
		if (bRoad) { // check if it road tile
			tmp = Instantiate (gameObj, new Vector3 (0, 0, worldPos), gameObj.transform.rotation); // create object
			worldPos += 4; // increment position for next object
		} else {
			int randPosition = Mathf.FloorToInt (Random.Range (-1, 2)); // roll for line
			tmp = Instantiate (gameObj, new Vector3 (randPosition, .7f, worldPos), gameObj.transform.rotation);
		}
		road.Add (tmp); // add created object to list
	}
}
