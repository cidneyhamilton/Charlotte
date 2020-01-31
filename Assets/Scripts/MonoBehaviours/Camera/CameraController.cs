using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {
    
    public class CameraController : Singleton<CameraController> {
	
	public Transform cameraTarget;
	
	Camera playerCamera;
	const float ZOOM_SPEED = 5f;
	const float DISTANCE = 10f;

	const int MAX_ZOOM = 100;
	const int MIN_ZOOM = 15;
	
	void Start() {
		playerCamera = GetComponent<Camera> ();
	}

	void Update() {		
		TrackPlayer();
		Zoom();
	}

	void Zoom() {
		if (Input.GetAxisRaw("Mouse ScrollWheel") != 0) {
			float scroll = Input.GetAxis ("Mouse ScrollWheel");
			playerCamera.fieldOfView -= scroll * ZOOM_SPEED;
			
			// Clamp zoom
			playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, MIN_ZOOM, MAX_ZOOM);
		}
	}

	void TrackPlayer() {
		// Assign player
		if (cameraTarget == null) {
			Player player = GameObject.FindObjectOfType<Player>();
			if (player != null) {
				cameraTarget = player.transform;
			}
		}

		if (cameraTarget != null) {		   
		    transform.position = new Vector3 (cameraTarget.position.x,
						      cameraTarget.position.y + DISTANCE,
						      cameraTarget.position.z - DISTANCE);
		}
	}
    }
}
