using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour {

	public Button pause_btn;
	public bool isPressed=false;
	public Sprite resume;
	public Sprite pause;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void pauseBtnAction()
	{
		if (!isPressed) {

			Time.timeScale = 0f;
			isPressed = true;
			pause_btn.image.sprite = resume;
		} 
		else
		{
			Time.timeScale = 1.0f;
			isPressed=false;
			pause_btn.image.sprite = pause;

		}
			
	}

}


