using System;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

using Cyborg.Scenes;

namespace Charlotte {
    
    public class DialogManager: MonoBehaviour {

	public delegate void OnContinue();
	public event OnContinue onContinue;
	
	public DialogView View;
	public ChoiceGroupView ChoiceView;

	private int dialogIndex;
	private Story _story;

	public string _npcName;
	public List<string> _dialogueLines = new List<string>();

	void OnEnable() {
	    StoryEvents.OnBeginStory += BeginStory;	    
	    StoryEvents.OnChoose += ChooseChoiceIndex;
	    StoryEvents.OnSay += SayText;
	    StoryEvents.OnAddDialogue += AddNewDialogue;
	}

	void OnDisable() {
	    StoryEvents.OnBeginStory -= BeginStory;
	    StoryEvents.OnChoose -= ChooseChoiceIndex;
	    StoryEvents.OnSay -= SayText;
	    StoryEvents.OnAddDialogue -= AddNewDialogue;
	}
	
	void Update() {
	    if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)) {
		Continue ();
	    }

	    if (_story != null) {
		HandleKeyEvents();
	    }
	}
	
	void HandleKeyEvents() {
	    if (_story.currentChoices.Count > 0) {
		// Make a choice using the alphanumeric keycode                                                                                  
                if (Input.GetKeyUp(KeyCode.Alpha1)) {
                    ChooseChoiceIndex(0);
                } else if (Input.GetKeyUp(KeyCode.Alpha2) && _story.currentChoices.Count > 0) {
                    ChooseChoiceIndex(1);
                } else if (Input.GetKeyUp(KeyCode.Alpha3) && _story.currentChoices.Count > 1) {
                    ChooseChoiceIndex(2);
                } else if (Input.GetKeyUp(KeyCode.Alpha4)  && _story.currentChoices.Count > 2) {
                    ChooseChoiceIndex(3);
                }

	    }
	}
	
	public void BeginStory(Story story) {
	    Debug.Log("Beginning story");
	    _story = story;
	    
	    // Allows stories to query the player's inventory
	    _story.BindExternalFunction ("has_item", (string itemKey) => {
		    Debug.Log(string.Format("Checking to see if player has {0}.", itemKey));
		    return InventoryController.Instance.HasItem(itemKey);
		});  
	    
	    _story.BindExternalFunction("is_wounded", () => {
		    return GameObject.FindObjectOfType<Player>().IsWounded();
		});
	    
	    _story.ObserveVariable("current_scene", (string varName, object sceneName) => {
		    Debug.Log("Switching scenes.");
		    SceneEvents.ChangeScene ((string) sceneName);
		});
	    
	    onContinue += AdvanceStory;
	    AdvanceStory();
	}
	
	public void AdvanceStory() {
	    if (_story.canContinue) {
		Debug.Log("Story can continue");
		UIEvents.Hide();
		
		string content = _story.Continue().Trim();
		View.Show(InkParser.Speaker(content), InkParser.Speech(content));			
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
	
	// Choose a given choice
	public void ChooseChoiceIndex(int choiceIndex) {
	    _story.ChooseChoiceIndex(choiceIndex);
	    if (_story.canContinue) {
		_story.Continue();
	    }
	    AdvanceStory();
	}

	// Say one line of dialogue, then end the dialogue
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

	    //Debug.Log("Adding callback");
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

}
