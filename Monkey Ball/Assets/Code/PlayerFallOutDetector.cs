using UnityEngine;
using System.Collections;

public class PlayerFallOutDetector : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Transform spawnPoint;

	void OnTriggerEnter(Collider c) {
		if (c.gameObject == player) {
			player.transform.position = spawnPoint.position;
			player.transform.rotation = spawnPoint.rotation;
		}
	}
}
