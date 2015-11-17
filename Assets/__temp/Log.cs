using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {
	public Player p;
	UnityEngine.UI.Text t;


	// Use this for initialization
	void Start () {
		t = GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = "Ocena: "+p.currentOcena + " ("+p.currentOcenaNormalized+")\nNastroj: "
			+p.currentNastroj+" ("+p.currentNastrojNormalized+")";
	}
}
