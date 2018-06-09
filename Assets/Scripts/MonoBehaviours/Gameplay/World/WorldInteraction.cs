using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

	public float RotationSpeed = 100f;

	const string INTERACTION_TAG = "Interactable Object";

	NavMeshAgent playerAgent;

	void Start () {
		playerAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {

		// If the left mouse button is clicked
		if (Input.GetMouseButtonDown (0)) {
			if (UnityEngine.EventSystems.EventSystem.current != null && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
				// If we're hovering over a UI element, do nothing
				return;
			}
			GetInteraction ();
		}

		if (Input.GetAxisRaw ("Horizontal") != 0) {
			playerAgent.enabled = false;
			transform.Rotate (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0);
			playerAgent.enabled = true;
		}

		if (Input.GetAxisRaw ("Vertical") != 0) {
			playerAgent.enabled = false;
			transform.Translate (0, 0, Input.GetAxis ("Vertical") * 5 * Time.deltaTime);
			playerAgent.enabled = true;
		}
	}
		
	void GetInteraction() {
		RaycastHit interactionInfo;
		if (Physics.Raycast(GetInteractionRay(), out interactionInfo, Mathf.Infinity)) {
			GameObject interactionObject = interactionInfo.collider.gameObject;
			if (interactionObject.tag == INTERACTION_TAG) {
				interactionObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);
			} else {
				Move (interactionInfo.point);
			}
		}
	}

	void Interact() {
		// TODO
	}

	void Move(Vector3 target) {
		playerAgent.SetDestination (target);
	}

	private Ray GetInteractionRay() {
		return Camera.main.ScreenPointToRay (Input.mousePosition);
	}
}
