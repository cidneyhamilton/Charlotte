public class NPC : Interactable {

    public ReactionCollection defaultReactionCollection;

	public override void Interact() {
		defaultReactionCollection.React ();   
	}
}
