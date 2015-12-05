using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour {






	public Button pause_btn;
	public bool isPressed=false;
	public Sprite resume;
	public Sprite pause;

    public AudioSource audioPause;
    public AudioSource audioLevelOne;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (audioPause);
		DontDestroyOnLoad (audioLevelOne);
       // audioPause = GetComponent<AudioSource>();
       // audioPause.Pause();

      //  audioLevelOne = GetComponent<AudioSource>();
      //  audioLevelOne.Play();
//        AudioSource[] audios = GetComponents<AudioSource>();
//        audioPause = audios[1];
//        audioLevelOne = audios[0];
//
//        audioPause.Pause();

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
			if(audioPause != null) audioPause.Play();
            if(audioLevelOne != null) audioLevelOne.Pause();

		} 
		else
		{
			Time.timeScale = 1.0f;
			isPressed=false;
			pause_btn.image.sprite = pause;
			if(audioPause) audioPause.Pause();
            if(audioLevelOne) audioLevelOne.Play();

        }
			
	}

}


