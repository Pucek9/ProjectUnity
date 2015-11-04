using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audio : MonoBehaviour {
    
    
    
    public AudioSource audioLevelOne;
	public bool flag = true;
    
    // Use this for initialization
	void Start () {
          audioLevelOne = GetComponent<AudioSource>();
          audioLevelOne.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
            if(flag)
            {
                audioLevelOne.Play();
                
            }
            else
            {
                audioLevelOne.Pause();
            }

	}
}
//   
//   
