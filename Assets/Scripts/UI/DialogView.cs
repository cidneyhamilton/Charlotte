using System.Collections;
using System.Collections.Generic;
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
		base.Awake ();
		this.dialogNameContainer = this.transform.Find ("Name");
		this.dialogName = dialogNameContainer.transform.GetChild(0).GetComponent<Text> ();
		this.dialogText = this.transform.Find ("Text").GetComponent<Text> ();
		Hide ();
	}

	// Set up the dialogue UI
	public void Show(string npcName, string line) {
		if (npcName == "") {
			this.dialogNameContainer.gameObject.SetActive (false);
		} else {
			this.dialogName.text = npcName;
			this.dialogNameContainer.gameObject.SetActive (true);
		}

		this.AddLine (line);
		this.gameObject.SetActive (true);

		// Feeze game
		// TODO: put this in a GameController or similar
		Time.timeScale = 0;
	}

	public void Hide() {
		// Unfreeze game
		// TODO: put this in a GameController or similar
		Time.timeScale = 1;

		this.gameObject.SetActive (false);
	}
}
