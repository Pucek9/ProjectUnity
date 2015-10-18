using UnityEngine;
using System.Collections;

public sealed class Character : MonoBehaviour {
	static Character _instance;
	
	public float speed;
	public float sens;

	// TODO: for optimization change these 3 lines to constants


	const float minX = -0.1375f;
	const float maxX = 0.1375f;
	const float goalZ = 29.36425f;

	bool gameRunning;
	bool gameEnded;
	// Use this for initialization
	void Start () {
		_instance = this;
		forwardSpeedVector = Vector3.forward * speed;
		leftSensVector = Vector3.left * sens;
	}

	float lastMousePos;

	static int points;
	public static void OnPointCollect() {
		points++;
	}

	static Vector3 mousePosCache;
	static Vector3 forwardSpeedVector;
	static Vector3 leftSensVector;
	
	// Update is called once per frame
	void Update () {
		if (gameEnded) {
			if(Input.GetMouseButtonDown(0)) Application.Quit();
		}
		mousePosCache = Input.mousePosition;
		if (gameRunning) {
			float deltaPos = 0;
			if(Input.GetMouseButtonDown(0)) {
				lastMousePos =  mousePosCache.x;
			}
			if(Input.GetMouseButton(0)) {
				deltaPos = lastMousePos - mousePosCache.x;
				deltaPos /= Screen.width;
			}
			Vector3 translation = forwardSpeedVector + leftSensVector*deltaPos;
			transform.Translate(translation);
			if(transform.position.x >maxX) {
				Vector3 pos = transform.position;
				pos.x = maxX;
				transform.position = pos;
			} else if(transform.position.x < minX) {
				Vector3 pos = transform.position;
				pos.x = minX;
				transform.position = pos;
			}
			if(transform.position.z >= goalZ) {
				gameEnded = true;
				gameRunning = false;
			}
		} else {
			if(Input.GetMouseButtonDown(0)) {
				gameRunning = true;
				lastMousePos = mousePosCache.x;
			}
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public static bool isGameRunning() {
		return _instance.gameRunning;
	}
	public static bool canSpawn() {
		return _instance.transform.position.z < goalZ - 4.5;
	}

	public static void Die() {
		_instance.gameRunning = false;
		_instance.gameEnded = true;
	}

	void OnGUI() {
		if (gameEnded) {
			GUI.Window(0, new Rect(Screen.width/5, Screen.height/5, 3*Screen.width/5, 3*Screen.height/5), ShowResults, "Results");
		}
	}
	void ShowResults(int id) {
		GUILayout.Label ("Your score: " + points);
	}
}

/*
 * -0.2525518
 * 4.592571
 * 9700.223
 * 
 * CHAR SIZE 0.2
 * 
 * font size 50
 * 
 * 
 * -0.2525493
 * 1.282124
 * 9742.364
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
