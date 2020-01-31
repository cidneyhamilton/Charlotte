using UnityEngine;

namespace Charlotte {
    
    public class ZoneTrigger : MonoBehaviour {
	
	public bool _recurring = false;
	
	bool triggeredEvent = false;
	
	public ReactionCollection defaultReactionCollection;
	
	void OnTriggerEnter(Collider col) {
	    if (col.tag == "Player") {
		Player player = col.gameObject.GetComponent<Player>();
		TriggerReaction(player);
	    }
	}

	void TriggerReaction(Player player) {
	    // Player entered the trigger
	
	    if (player == null) {
		Debug.LogWarning("No player found.");
	    } else {
		player.Stop();
		// TODO: Make sure the player is on the outside of the trigger
	    }
	    
	    if (_recurring) {
		// If the event is recurring, always react
		defaultReactionCollection.React (); 
	    } else if (!triggeredEvent) {
		// If it's not recurring, make sure the event is only triggered once
		triggeredEvent = true;
		defaultReactionCollection.React (); 
	    }
	    
	}
	
    }
}
