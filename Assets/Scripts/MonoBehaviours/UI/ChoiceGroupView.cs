using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

namespace Charlotte {
    
    public class ChoiceGroupView : Singleton<ChoiceGroupView> {
	
	// List of available choices
	public List<ChoiceView> choiceViews;
	
	// Template for what a choice should look like
	public ChoiceView choiceViewPrefab;

	void OnEnable() {
	    UIEvents.OnHide += Hide;
	}

	void OnDisable() {
	    UIEvents.OnHide -= Hide;
	}
	
	protected override void Awake() {
	    foreach(Transform child in transform) {
		Destroy(child.gameObject);
	    }
	    Hide();
	    choiceViews = new List<ChoiceView>();
	}
	
	public void Show(IList<Choice> choices) {
	    CreateChoices(choices);
	    gameObject.SetActive(true);
	    if (choices.Count > 0) {
		foreach (ChoiceView choiceView in choiceViews) {
		    choiceView.Render();
		}
	    }
	    Time.timeScale = 0;
	    
	}
	
	public void MakeChoice(Choice choice) {
	    // Choice made
	    ClearChoices();
	    Hide();
	    StoryEvents.Choose(choice.index);
	}
	
	void CreateChoices(IList<Choice> choices) {
	    ClearChoices();
	    
	    foreach(Choice choice in choices) {
		LayoutChoice(choice);
	    }  
	}
	
	private void ClearChoices() {
	    foreach(Transform child in transform) {
		Destroy(child.gameObject);
	    }
	    choiceViews.Clear();
	}
	
	public ChoiceView LayoutChoice(Choice choice) {
	    ChoiceView choiceView = Instantiate(choiceViewPrefab);
	    choiceView.transform.SetParent(transform, false);
	    choiceView.choiceGroupView = this;
	    choiceView.LayoutText(choice);
	    choiceView.button.onClick.AddListener(delegate { MakeChoice(choice); });
	    choiceViews.Add(choiceView);
	    return choiceView;
	}
	
	public void Hide() {
	    Time.timeScale = 1;
	    gameObject.SetActive (false);
	}
	
    }

}
