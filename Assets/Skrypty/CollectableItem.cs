using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : Itemki {

    public Renderer rend;   //renderer Sprite
	public int nastroj = 0;
	public int oceny = 0;

    public AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio.Stop();
    }
	protected override void zderzenie(Player gracz){
		
        //
        audio.Play();
        //
      
        Debug.Log ("CollectableItem.zderzenie");
		gracz.zmianaNastroju (nastroj);
		gracz.zmianaOceny (oceny);

		if (nastroj <= 0) 
		
		{
			gracz.gameOver(nastroj,oceny);

		}
       // Destroy(this.gameObject);
        rend.enabled = false;
	}
	protected override void OnTriggerEnter(Collider c) {
        base.OnTriggerEnter(c);
	}

}
