using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	void OnTriggerEnter() {
		Character.Die ();
	}
}
