using UnityEngine;

public class ZoneTrigger : MonoBehaviour {

	bool triggeredEvent = false;

	public ReactionCollection defaultReactionCollection;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" && !triggeredEvent) {
			// Player entered this zone; trigger an event
			triggeredEvent = true;
			defaultReactionCollection.React ();	
		}
	}
		
}
