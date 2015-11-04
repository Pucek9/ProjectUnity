using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class new_onClick : MonoBehaviour {

    //FR
    public GameObject g_trackBar;
    private  bool active = true;
    public Sprite wlacz_glos;
    public Slider s_trackBar;
    public Sprite wylacz_glos;
    public Button myBtn;
    float glos;

    // Use this for initialization
    void Start () {


	
    }
	
	// Update is called once per frame
	void Update () {


      


        if (s_trackBar.value == 0)
        {
            myBtn.image.sprite = wylacz_glos;
        }
        if(s_trackBar.value != 0)
        {
            myBtn.image.sprite = wlacz_glos;
        }

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

            //FR
            case "sound_btn":
                {
                    glos = s_trackBar.value;
                   // 
                    if (s_trackBar.value == 0)
                    {
                        
                    }
                    else
                    {
                        s_trackBar.value = 0;
                    }
                    if (active == true)
                    {
                        g_trackBar.SetActive(false);
                        active = false;
                    }
                    else
                    {
                        g_trackBar.SetActive(true);
                        active = true;
                    }
                   // s_trackBar.value = glos;


                    break;
                }
           
           
            default:
                Debug.Log("error");
                break;
        }

    }

    



}
