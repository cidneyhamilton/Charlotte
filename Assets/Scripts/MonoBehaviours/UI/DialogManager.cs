using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogManager : Singleton<DialogManager> {

	public DialogView View;
	public ChoiceGroupView ChoiceView;

	public delegate void OnContinue();
	public event OnContinue onContinue;

	private int dialogIndex;
	private Story _story;

	public string _npcName;
	public List<string> _dialogueLines = new List<string>();

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
			Continue ();
		}
	}

	public void BeginStory(Story story) {
		Debug.Log("Beginning story");
		_story = story;
		onContinue += AdvanceStory;
		AdvanceStory();
	}

	public void AdvanceStory() {
		if (_story.canContinue) {
			Debug.Log("Story can continue");
			string content = _story.Continue().Trim();
			AddNewDialogue(content);			
		} else {
			Debug.Log("Story can't continue");
			// Show Choices
			if (_story.currentChoices.Count > 0) {
				Debug.Log("Choices remaining.");
				View.Hide();
				ChoiceView.Show(_story.currentChoices);
			} else {
				Debug.Log("Out of choices.");
				// TODO: Out of choices
				ChoiceView.Hide();
				View.Hide();
				onContinue -= AdvanceStory;
			}		
		}	
	}

	public void ChooseChoiceIndex(int choiceIndex) {
		Debug.Log("Choosing choice index");
		_story.ChooseChoiceIndex(choiceIndex);
		_story.Continue();
		AdvanceStory();
	}

	public void SayText(string line) {
		AddNewDialogue(line);
        onContinue += CompleteDialogue;
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
		Debug.Log("Adding callback");
		onContinue += NextLine;
	}

	// Continue button in the UI
	public void Continue() {
		if (onContinue != null) {
			Debug.Log("Continuing.");
			onContinue();
		}	
	}

	private void NextLine() {
		if (dialogIndex < _dialogueLines.Count - 1) {
			dialogIndex++;
			View.AddLine (_dialogueLines [dialogIndex]);
		} else {
			dialogIndex = 0;
			View.Hide ();
			onContinue -= NextLine;
		}
		
	}

	private void CompleteDialogue() {
		// Reset the dialogue index, in case it repeats
		dialogIndex = 0;
		View.Hide ();
		onContinue -= CompleteDialogue;
	}
}
