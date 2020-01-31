using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

namespace Charlotte {
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
            return transform.GetChild(0).GetComponent<Text>();
        }
    }

    protected void Awake() {
        button.interactable = false;
    }

    public void LayoutText(Choice choice) {
        content = choice.text.Trim();
    }

    public void Render() {
        text.text = content;
        Show();
    }

    public void Show() {
        button.enabled = true;
        button.interactable = true;
    }

    private void MakeChoice() {
        choiceGroupView.MakeChoice(choice);
    }

    public void OnClick() {
        MakeChoice();
    }
}

}
