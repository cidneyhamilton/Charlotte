using UnityEngine;

public class ZoneTrigger : MonoBehaviour {

    public bool _recurring = false;

	bool triggeredEvent = false;

	public ReactionCollection defaultReactionCollection;

	void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            // Player entered the trigger
            Player player = col.gameObject.GetComponent<Player>();
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
