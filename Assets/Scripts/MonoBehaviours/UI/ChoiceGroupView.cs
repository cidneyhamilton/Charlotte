using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ChoiceGroupView : Singleton<ChoiceGroupView> {

    public Text dialogText;

    // List of available choices
	public List<ChoiceView> choiceViews;

    // Template for what a choice should look like
    public ChoiceView choiceViewPrefab;

    protected override void Awake() {
        dialogText = transform.Find ("Text").GetComponent<Text> ();
        Hide();
    }

    public void MakeChoice(Choice choice) {
        // Choice made
        Debug.Log("Choice made.");
    }

    void CreateChoices(IList<Choice> choices) {
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

    public void Show(IList<Choice> choices) {
        CreateChoices(choices);
        if (choices.Count > 0) {
            foreach (ChoiceView choiceView in choiceViews) {
                choiceView.Render();
            }
        }
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    
    public void Hide() {
        Time.timeScale = 1;
        gameObject.SetActive (false);
    }


}
