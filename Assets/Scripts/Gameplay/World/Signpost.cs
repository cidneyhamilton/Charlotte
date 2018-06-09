using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signpost : ActionItem {

	public string description;

	public override void Interact() {
		DialogManager.Instance.AddNewDialogue (description);
		Debug.Log ("Interacting with Signpost class.");
	}
}
