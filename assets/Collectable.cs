using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	void OnTriggerEnter() {
		Character.OnPointCollect ();
		Destroy (gameObject);
	}
}
