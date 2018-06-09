using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

	public float PlayerCameraDistance { get; set; }
	public Transform cameraTarget;

	Camera playerCamera;
	const float ZOOM_SPEED = 5f;
	const float DISTANCE = 10f;

	void Start() {
		PlayerCameraDistance = DISTANCE;
		playerCamera = GetComponent<Camera> ();
	}

	void Update() {
		if (Input.GetAxisRaw("Mouse ScrollWheel") != 0) {
			Zoom();
		}
		
		transform.position = GetCameraPosition ();
	}

	void Zoom() {
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		playerCamera.fieldOfView -= scroll * ZOOM_SPEED;

		// Clamp zoom
		playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 15, 100);
	}

	Vector3 GetCameraPosition() {
		if (cameraTarget == null) {
			return new Vector3();
		}
		return new Vector3 (
			cameraTarget.position.x,
			cameraTarget.position.y + PlayerCameraDistance,
			cameraTarget.position.z - PlayerCameraDistance
		);
	}
}
