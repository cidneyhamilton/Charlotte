using UnityEngine;

public class ActionItem : Interactable {

    public ReactionCollection defaultReactionCollection;

	public override void Interact() {
		Debug.Log ("Interacting with Action Item.");
        defaultReactionCollection.React ();
	}
}
