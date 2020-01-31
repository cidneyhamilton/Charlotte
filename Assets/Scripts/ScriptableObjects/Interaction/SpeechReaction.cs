using UnityEngine;

namespace Charlotte {
    
    public class SpeechReaction : Reaction {
	
	public string speakerName;                  // The name of the character speaking the text
	public string[] messages;                      // The text to be displayed to the screen.
	
	protected override void ImmediateReaction()
	{
	    StoryEvents.AddDialogue(messages, speakerName);
	}
    }

}
