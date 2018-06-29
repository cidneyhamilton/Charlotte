using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : Singleton<InventoryController> {

	public List<Item> playerItems = new List<Item>();
	public WeaponController playerWeaponController;

	void Start() {
		playerWeaponController = GetComponent<WeaponController> ();
		// Add starting items
		AddItem ("longsword");
		AddItem ("staff");
	}

	public void AddItem(string itemKey) {
		Item item = GetItemFromKey (itemKey);
		if (item == null) {
			Debug.LogError ("No item found with key " + itemKey);
		}
		if (playerItems.Contains (item)) {
			// Already have this item
			Debug.LogWarning("Inventory already has " + itemKey);
		} else {
			playerItems.Add (item);
			UIEventHandler.Acquired (item);
		}
	}

    public void AddItem(Item item) {
        AddItem(item.itemName);
    }

	public void RemoveItem(string itemKey) {
		Item item = GetItemFromKey (itemKey);
		playerItems.Remove (item);
	}

	public void EquipItem(Item itemToEquip) {
		playerWeaponController.EquipWeapon (itemToEquip);
	}

	private Item GetItemFromKey(string itemKey) {
		return ItemDatabase.Instance.GetItem (itemKey);
	}

}
