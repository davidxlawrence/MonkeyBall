using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform cameraTransform;
	
	private Rigidbody rb;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		Vector3 movement = Input.GetAxis("Vertical")* cameraTransform.forward + Input.GetAxis("Horizontal") * cameraTransform.right;
		movement.y = 0f;

		//Vector3 relativeMovement = cameraTransform.TransformDirection(movement);
		//relativeMovement = new Vector3(relativeMovement.x, 0, relativeMovement.z);
		rb.AddForce(movement * speed);

		Debug.DrawRay (transform.position, rb.velocity, Color.red);
	}
}