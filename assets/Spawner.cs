using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject obstacle;
	public float spawnDelay;
	
	public float[] lanes;

	float nextSpawnTime;

	public bool multiple;

	int rndLane;
	// Update is called once per frame
	void Update () {
		if (!Character.isGameRunning ())
						return;
		if (Time.time < nextSpawnTime) return;
		if (/*Character.isGameRunning ()*/ Character.canSpawn()) {
			rndLane = Random.Range(0,lanes.Length);
			if(multiple) {
				for(int i = 0; i<lanes.Length; i++) {
					if(i == rndLane) {
						continue;
					}
					Vector3 pos = transform.position;
					pos.x = lanes[i];
					Instantiate(obstacle, pos, Quaternion.identity);
				}
			} else {
				Vector3 pos = transform.position;
				pos.x = lanes[rndLane];
				Instantiate(obstacle, pos, Quaternion.identity);
			}
			nextSpawnTime = Time.time + spawnDelay;
		}
	}
}
