using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

	protected NavMeshAgent playerAgent;

	private bool hasInteracted;

	void Awake() {
		tag = "Interactable Object";
	}

	public virtual void MoveToInteraction(NavMeshAgent agent) 
	{
		Debug.Log("moving to interaction");
		hasInteracted = false;
		playerAgent = agent;
		playerAgent.stoppingDistance = 1f;
		playerAgent.destination = transform.position;
	}
		
	void Update() {
		if (hasInteracted) {
			return;
		}
		if (playerAgent == null) {
			return;
		}
        
		if (playerAgent.pathPending) {
			Debug.Log("Path pending.");
			return;
		}
		if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {
				Debug.Log("Interacting");
				Interact ();
				hasInteracted = true;
		}
	}

	public virtual void Interact() {
		Debug.Log ("Interacting with base class.");
	}
}
