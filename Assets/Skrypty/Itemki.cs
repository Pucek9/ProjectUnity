using UnityEngine;
using System.Collections;

public abstract class Itemki : MonoBehaviour {

	protected abstract void zderzenie(Player gracz);

	protected virtual void OnTriggerEnter(Collider c) {
		Player p = c.gameObject.GetComponent<Player> ();
		if (p != null) {
			zderzenie (p);
		}
	}
}
