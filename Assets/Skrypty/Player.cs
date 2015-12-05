using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static Player instance;

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
	bool sesja = false;
	public bool isRunning {
		get {return start;}
	}
	// float skrecanie = 0; w zalenozsci od dzialania klawiszy
	Vector3 normalizacjaMyszy;
	static public int ocena = 0;
	public UnityEngine.UI.Text timerUI;
	static public int nastroj = 0;
	public float game_time = 4 * 60f;
	float gameTimer;

	public void zmianaNastroju(int obliczanieNastroj){

		nastroj += obliczanieNastroj;

	}

	public void zmianaOceny(int obliczanieOceny){

		ocena += obliczanieOceny;

	}

	public void gameOver (int nastroj, int oceny)
	{

		Application.LoadLevel("game_over");


	}
	
	float sterowanie(float pos) {
		float skrecanie = 0;
		pos = (pos * 2) - 1;

		skrecanie = (predkoscSkrecania * Time.deltaTime) * pos ;
		return skrecanie;
	}

	AudioListener al;
	// Use this for initialization
	void Start () {
		instance = this;
		gameTimer = game_time;
		al = FindObjectOfType<AudioListener> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			al.enabled ^= true;
		}
		if (sesja) {
			return;
		}
		if (start) {
			gameTimer -= Time.deltaTime;
			timerUI.text = string.Format("{0}:{1:00}", (int)(gameTimer / 60), (int)(gameTimer) %60 );
		}
		if (gameTimer < 0) {
			start = false;
			sesja = true;
			ShowSesjaUI();
			return;
		}

		float skrecanie2 = 0;

		
		if (Input.GetMouseButtonDown (0) && !sesja) {
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


	void ShowSesjaUI() {
		Debug.Log ("SESJA!");
		// TODO: pokazac przycisk "koniec zwyklego trybu, przejscie do sesji"
	}
	
}
