using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	private Vector3 _offset;

	public void Start()
	{
		_offset = transform.position - player.transform.position;
	}
	
	public void Update()
	{
		transform.position = player.transform.position + _offset;
		transform.LookAt (player.transform);
	}

//	const float distance = 10f;
//
//	private Rigidbody playerRigidBody;
//
//	void Start() {
//		playerRigidBody = player.GetComponent<Rigidbody>();
//	}
//	
//	void Update() {
//		Vector3 direction = playerRigidBody.velocity.normalized;
//		Vector3 offset = * direction * distance;
//		transform.position = player.transform.position - offset;
//		transform.LookAt(player.transform);
//	}
}