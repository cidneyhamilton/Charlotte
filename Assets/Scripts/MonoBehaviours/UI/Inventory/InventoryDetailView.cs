using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDetailView : Singleton<InventoryDetailView> {

	Item item;
	Button selectedItemButton, itemInteractButton;
	Text itemNameText, itemDescriptionText, itemInteractButtonText;

	void Start() {
		this.itemNameText = transform.Find ("Item_Name").GetComponent<Text> ();
		this.itemDescriptionText = transform.Find ("Item_Description").GetComponent<Text> ();

		this.itemInteractButton = transform.Find ("Interact_Button").GetComponent<Button> ();
		this.itemInteractButtonText = itemInteractButton.transform.Find("Text").GetComponent<Text> ();

		this.gameObject.SetActive (false);
	}

	public void SetItem(Item item, Button selectedItemButton) {
		this.gameObject.SetActive (true);

		this.itemInteractButton.onClick.RemoveAllListeners ();
		this.selectedItemButton = selectedItemButton;

		this.item = item;
		this.itemNameText.text = item.itemName;
		this.itemDescriptionText.text = item.description;

		// TODO: Get this from the item
		this.itemInteractButtonText.text = "Equip";
		this.itemInteractButton.onClick.AddListener (OnItemInteract);

	}

	public void OnItemInteract() {
		Debug.Log ("Interacting with " + item.itemName);
		if (item.itemType == Item.Type.Weapon) {
			InventoryController.Instance.EquipItem (item);
			Destroy (selectedItemButton.gameObject);
		}
		this.item = null;
		this.gameObject.SetActive (false);

	}

}
