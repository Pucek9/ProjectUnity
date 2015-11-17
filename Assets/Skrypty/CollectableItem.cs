using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : Itemki {

	public int nastroj = 0;
	public int oceny = 0;

	protected override void zderzenie(Player gracz){
		Debug.Log ("CollectableItem.zderzenie");
		gracz.zmianaNastroju (nastroj);
		gracz.zmianaOceny (oceny);

		Destroy (this.gameObject);
	}
	protected override void OnTriggerEnter(Collider c) {
		base.OnTriggerEnter (c);
	}
}
