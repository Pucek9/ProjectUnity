using UnityEngine;
using System.Collections;

public class ShowThis : MonoBehaviour {
	public Color color = Color.white;
	public float r;
	void OnDrawGizmos() {
		Gizmos.color = color;
		Gizmos.DrawWireSphere(transform.position,r);
	}
}
