using UnityEngine;
using System.Collections;

public class new_onClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void buttonAction (string buttonName)
	{
		switch (buttonName) 
		{
		case "new_game_btn":
//			Application.LoadLevel("lvl1");
			Application.LoadLevel("Game");
				break;
		case "exit_btn":
			Application.Quit();
			break;
		default:
			Debug.Log("error");
			break; 
		}


	}
}
