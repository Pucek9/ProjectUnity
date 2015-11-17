using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {
	public GameObject[] itemPrefabs;
	public float spawnDistance;
	public int minItems = 1;
	public int maxItems = 3;
	public Transform[] lanes;
	public Transform itemAnchor;
	// v = s/t => t = s/v

	int itemTypeAmountCache;
	int lanesAmountCache;
	Player p;
	float timer;
	bool[] usedLanes;

	void Start() {
		itemTypeAmountCache = itemPrefabs.Length;
		lanesAmountCache = lanes.Length;
		if (maxItems > lanesAmountCache) maxItems = lanesAmountCache;
		usedLanes = new bool[lanesAmountCache];
		p = FindObjectOfType<Player> ();
		timer = 0;
	}

	void Update() {
		Vector3 pos = transform.position;
		pos.x = 0;
		transform.position = pos;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Spawn();
			timer = spawnDistance / p.predkosc;
		}
	}

	void Spawn() {
		for (int i=0; i<lanesAmountCache; i++)
			usedLanes [i] = false;
		int rnd2 = Random.Range (minItems, maxItems);

		for (int i=0; i<rnd2; i++) {
			int rnd1 = Random.Range (0, itemTypeAmountCache - 1);
			int rnd3 = Random.Range(0, lanesAmountCache -1);
			while(usedLanes[rnd3]) {
				rnd3 = (rnd3+1) % lanesAmountCache;
			}
			usedLanes[rnd3] = true;
			GameObject g = Instantiate(itemPrefabs[rnd1]);
			g.transform.position = lanes[rnd3].transform.position;
			g.transform.parent = itemAnchor;
		}
	}
}
