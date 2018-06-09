using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

	protected NavMeshAgent playerAgent;

	private bool hasInteracted;

	void Awake() {
		this.tag = "Interactable Object";
	}

	public virtual void MoveToInteraction(NavMeshAgent playerAgent) 
	{
		this.hasInteracted = false;
		this.playerAgent = playerAgent;
		this.playerAgent.stoppingDistance = 1f;
		this.playerAgent.destination = this.transform.position;
	}
		
	void Update() {
		if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {
				Interact ();
				hasInteracted = true;
			}
		}
	}

	public virtual void Interact() {
		Debug.Log ("Interacting with base class.");
	}
}
