using UnityEngine;
using System.Collections;

public class LevelTilter : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxRotationAngle;

	void Start() {
		foreach(Transform t in transform) {
			t.gameObject.tag = transform.tag;
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		if (moveHorizontal == 0 && moveVertical == 0) {
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed * 0.1f);
		} else {
			transform.Rotate (moveHorizontal * speed * Time.deltaTime, 0, moveVertical * speed * Time.deltaTime);

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