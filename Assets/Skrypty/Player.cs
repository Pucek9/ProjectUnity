using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float predkosc = 1;
	public float predkoscSkrecania = 1;
	bool start = false;	
	// float skrecanie = 0; w zalenozsci od dzialania klawiszy
	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float skrecanie = 0;
		
		
		if (Input.GetMouseButtonDown (0)) {
			start = !start;
		}
		
		
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			skrecanie = -(predkoscSkrecania) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			skrecanie = predkoscSkrecania * Time.deltaTime;
		}
		
		
		//		if (Input.GetMouseButtonDown (1)) {
		//			start = false;
		//		}
		
		
		if (start) {
			transform.Translate (skrecanie, 0, predkosc * Time.deltaTime);
		}
		
		Vector3 pozycja = transform.position;
		pozycja.x = Mathf.Clamp (pozycja.x, -2, 2);
		transform.position = pozycja;
		
	}
	
}
