using UnityEngine;

public class SpeechReaction : Reaction {

    public string speakerName;                  // The name of the character speaking the text
    public string[] messages;                      // The text to be displayed to the screen.

    protected override void ImmediateReaction()
    {
        Debug.Log("Text reaction reacting.");
        DialogManager.Instance.AddNewDialogue (messages, speakerName);
    }
}
