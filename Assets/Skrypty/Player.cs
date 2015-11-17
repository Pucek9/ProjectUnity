using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int currentOcena {
		get {
			return ocena;
		}
	}
	public int currentNastroj {
		get {
			return nastroj;
		}
	}
	public float currentOcenaNormalized {
		get {
			return (float)ocena / maxOcena;
		}
	}
	public float currentNastrojNormalized {
		get {
			return (float)nastroj / maxNastroj;
		}
	}

	public int maxOcena;
	public int maxNastroj;
	public float predkosc = 1;
	public float predkoscSkrecania = 1;
	bool start = false;	
	// float skrecanie = 0; w zalenozsci od dzialania klawiszy
	Vector3 normalizacjaMyszy;
	int ocena = 0;
	int nastroj = 0;

	public void zmianaNastroju(int obliczanieNastroj){

		nastroj += obliczanieNastroj;

	}

	public void zmianaOceny(int obliczanieOceny){

		ocena += obliczanieOceny;

	}
	
	float sterowanie(float pos) {
		float skrecanie = 0;
		pos = (pos * 2) - 1;

		skrecanie = (predkoscSkrecania * Time.deltaTime) * pos ;
		return skrecanie;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float skrecanie2 = 0;

		
		if (Input.GetMouseButtonDown (0)) {
			//start = !start;
			start = true;

		}

		//mousePosition = normalizacjaMyszy;
		normalizacjaMyszy = Input.mousePosition;
		normalizacjaMyszy.x = normalizacjaMyszy.x/Screen.width;
		normalizacjaMyszy.y = normalizacjaMyszy.y/Screen.height;

		if (normalizacjaMyszy.y < 0.80) {
			skrecanie2 = sterowanie(normalizacjaMyszy.x);
			// 80% ekranu - do naciskania
		} else {
			// 20% ekranu - miejsce na przyciski 
		}

		#region stary kod 
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			skrecanie2 = -(predkoscSkrecania) * Time.deltaTime;
//		}
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			skrecanie2 = predkoscSkrecania * Time.deltaTime;
//		}
//		
		
		//		if (Input.GetMouseButtonDown (1)) {
		//			start = false;
		//		}
		#endregion 
		
		if (start) {
			transform.Translate (skrecanie2, 0, predkosc * Time.deltaTime);
		}
		
		Vector3 pozycja = transform.position;
		pozycja.x = Mathf.Clamp (pozycja.x, -2, 2);
		transform.position = pozycja;
		
	}
	
}
