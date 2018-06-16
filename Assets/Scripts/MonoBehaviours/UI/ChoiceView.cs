using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

[RequireComponent(typeof(Button))]
public class ChoiceView : MonoBehaviour {

    // Parent container; has all of the choices
    public ChoiceGroupView choiceGroupView;

    // The Choice in ink
    public Choice choice;

    public string content;

    public Button button {
        get {
            return GetComponent<Button>();
        }
    }

    public Text text {
        get {
            return GetComponent<Text>();
        }
    }

    public void LayoutText(Choice choice) {
        content = choice.text.Trim();
        text.text = content;
        Show();
    }

    public void Show() {
        button.enabled = true;
        button.interactable = true;
    }

    protected void Awake() {
        button.interactable = false;
    }

    protected void Update() {
        if(Input.GetKeyDown((choice.index+1).ToString())) {
            MakeChoice();
        }
    }

    private void MakeChoice() {
        choiceGroupView.MakeChoice(choice);
    }

    public void OnClick() {
        MakeChoice();
    }
}
