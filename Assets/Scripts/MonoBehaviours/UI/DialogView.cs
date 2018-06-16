using UnityEngine;
using UnityEngine.UI;

public class DialogView : Singleton<DialogView> {

	public Transform dialogNameContainer;
	public Text dialogName, dialogText;

	private int index;

	public void AddLine(string newText) {
		dialogText.text = newText;
	}

	protected override void Awake() {
		dialogNameContainer = transform.Find ("Name");
		dialogName = dialogNameContainer.transform.GetChild(0).GetComponent<Text> ();
		dialogText = transform.Find ("Text").GetComponent<Text> ();
		Hide();
	}

	// Set up the dialogue UI
	public void Show(string npcName, string line) {
		if (npcName == "") {
			dialogNameContainer.gameObject.SetActive (false);
		} else {
			dialogName.text = npcName;
			dialogNameContainer.gameObject.SetActive (true);
		}

		AddLine (line);
		gameObject.SetActive (true);

		// Freeze game
		// TODO: put this in a GameController or similar
		Time.timeScale = 0;
	}

	public void Hide() {
		// Unfreeze game
		// TODO: put this in a GameController or similar
		Time.timeScale = 1;

		gameObject.SetActive (false);
	}
}
