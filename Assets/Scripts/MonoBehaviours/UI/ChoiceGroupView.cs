using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ChoiceGroupView : Singleton<ChoiceGroupView> {

    // List of available choices
	public List<ChoiceView> choiceViews;

    // Template for what a choice should look like
    public ChoiceView choiceViewPrefab;

    void Awake() {
        Hide();
    }

    public void MakeChoice(Choice choice) {
        // Choice made
        Debug.Log("Choice made.");
    }

    public void LayoutChoices(IList<Choice> choices) {
        foreach(Choice choice in choices) {
            LayoutChoice(choice);
        }
    }

    public ChoiceView LayoutChoice(Choice choice) {
        ChoiceView choiceView = Instantiate(choiceViewPrefab);
        choiceView.transform.SetParent(transform, false);
        choiceView.choiceGroupView = this;
        choiceView.LayoutText(choice);
        choiceViews.Add(choiceView);
        return choiceView;
    }

    
    public void Hide() {
        gameObject.SetActive (false);
    }


}
