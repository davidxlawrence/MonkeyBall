using UnityEngine;
using System.Collections;

public class LevelTilter : MonoBehaviour {

	[SerializeField]
	private Transform cameraTransform;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxRotationAngle;

	[SerializeField]
	private float rotationResetSpeed;

	private Quaternion _originalRotation;

	void Start() {
		_originalRotation = transform.localRotation;
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = -Input.GetAxis("Horizontal") * cameraTransform.forward + Input.GetAxis("Vertical") * cameraTransform.right;
		movement.y = 0f;

		if (moveHorizontal == 0 && moveVertical == 0) {
			transform.localRotation = Quaternion.Lerp(transform.localRotation, _originalRotation, Time.deltaTime * rotationResetSpeed);
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
		} else {
			transform.Rotate(movement * speed * Time.deltaTime);

			float x = transform.localEulerAngles.x;
			float z = transform.localEulerAngles.z;
			
			transform.localEulerAngles = new Vector3(ClampAngle(x, -maxRotationAngle, maxRotationAngle),
			                                         0,
			                                         ClampAngle(z, -maxRotationAngle, maxRotationAngle));
		}
	}

	private float ClampAngle(float angle, float min, float max) {
		
		if (angle < 90 || angle > 270) {
			if (angle > 180) {
				angle -= 360;
			}

			if (max > 180) {
				max -= 360;
			}

			if (min > 180) {
				min -= 360;
			}
		}    

		angle = Mathf.Clamp(angle, min, max);

		if (angle < 0) {
			angle += 360;
		}

		return angle;
	}
}