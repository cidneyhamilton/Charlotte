using System.Collections.Generic;
using UnityEngine;

public class DialogManager : Singleton<DialogManager> {

	public DialogView View;

	private int dialogIndex;

	public string _npcName;
	public List<string> _dialogueLines = new List<string>();

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
			Continue ();
		}
	}

	// Add one line of dialogue
	public void AddNewDialogue(string line) {
		_dialogueLines = new List<string> ();
		_dialogueLines.Add (line);
		View.Show ("", line);
	}

	// Add multiple lines of dialogue
	public void AddNewDialogue(string[] lines, string npcName) {
		_dialogueLines = new List<string> ();
		_dialogueLines.AddRange (lines);
		View.Show (npcName, _dialogueLines [0]);
	}

	// Continue button in the UI
	public void Continue() {
		if (dialogIndex < _dialogueLines.Count - 1) {
			dialogIndex++;
			View.AddLine (_dialogueLines [dialogIndex]);
		} else {
			// Reset the dialogue index
			dialogIndex = 0;
			View.Hide ();
		}
	}
}
