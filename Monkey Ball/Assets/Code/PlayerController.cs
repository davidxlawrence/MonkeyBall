using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;
	
	private Rigidbody rb;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 relativeMovement = Camera.main.transform.TransformDirection(movement);
		relativeMovement = new Vector3 (relativeMovement.x, 0, relativeMovement.z);
		rb.AddForce (relativeMovement * speed);
	}
}