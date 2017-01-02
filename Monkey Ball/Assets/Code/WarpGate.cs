using UnityEngine;
using System.Collections;

public class WarpGate : MonoBehaviour {

	[SerializeField]
	private GameObject player;
	
	[SerializeField]
	private GameObject targetGate;
	
	void OnTriggerEnter(Collider c) {
		if (c.gameObject == player) {
			player.transform.position = targetGate.transform.position + targetGate.transform.forward;
		}
	}
}