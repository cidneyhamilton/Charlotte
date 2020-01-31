using UnityEngine;

namespace Charlotte {
    
    public class TextReaction : Reaction {
	
	public string message;                      // The text to be displayed to the screen.
	
	protected override void ImmediateReaction()
	{
	    Debug.Log("Text reaction reacting.");
	    DialogManager.Instance.SayText (message);
	}
    }
}
