using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : Singleton<InventoryView> {

	public RectTransform inventoryPanel;
	public RectTransform scrollViewContent;
	public InventoryItemView itemContainer { get; set; }

	bool menuIsActive = false;
	Item selectedItem { get; set; }

	void Awake() {
		inventoryPanel.gameObject.SetActive (false);
		itemContainer = Resources.Load<InventoryItemView> ("UI/Item_Container");
		// UIEventHandler.OnAcquired += ItemAdded; 
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			this.menuIsActive = !menuIsActive;
			inventoryPanel.gameObject.SetActive (menuIsActive);
		}
	}

	public void ItemAdded(Item item) {
		InventoryItemView emptyItem = Instantiate (itemContainer);
		emptyItem.SetItem (item);
		emptyItem.transform.SetParent (scrollViewContent);
	}

}
