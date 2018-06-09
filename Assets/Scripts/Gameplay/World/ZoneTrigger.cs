using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour {

	public Encounter encounter;
	bool triggeredEvent;

	void Start() {
		triggeredEvent = false;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && !triggeredEvent) {
			// Player entered this zone; trigger an event
			triggeredEvent = true;
			Event1();

		}
	}

	void Event1() {
		encounter.gameObject.SetActive (true);

		string[] lines = {
			"Roads aren't safe around here...",
			"I am Alexander and I am your end.",
			"Boys, get him... or her, whatever. Go!"
		};
		DialogManager.Instance.AddNewDialogue(lines, "Alexander");
	}
		
}
