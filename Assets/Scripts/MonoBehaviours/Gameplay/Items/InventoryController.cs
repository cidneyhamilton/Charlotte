using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : Singleton<InventoryController> {

	// Represents the player's inventory
	public List<Item> playerItems = new List<Item>();

	// Checks to see if the player already has the specified item
	public bool HasItem(Item item) {
		return playerItems.Contains (item);
	}

	public bool HasItem(string itemKey) {
		Item item = GetItemFromKey (itemKey);
		if (item == null) {
			Debug.Log("Item named " + itemKey + " cannot be found in database");
			return false;
		} else {
			bool result = HasItem(item);
			if (result) {
				Debug.Log(string.Format("Player has the {0}.", itemKey));
			} else {
				Debug.Log(string.Format("Player does not have the {0}.", itemKey));
			}
			return result;
		}
		
	}

	// Adds item by key
	public void AddItem(string itemKey) {
		Item item = GetItemFromKey (itemKey);
		if (HasItem(item)) {
			Debug.LogWarning("Player already has this item.");
			// Player already has this item!
		} else {
			// Add the item to the player's inventory
			Debug.Log("Adding item to the player inventory.");
			playerItems.Add (item);
		}
	}

	// Adds item by Item instance
    public void AddItem(Item item) {
        AddItem(item.itemName);
    }


    // Removes an item by key
	public void RemoveItem(string itemKey) {
		Item item = GetItemFromKey (itemKey);
		playerItems.Remove (item);
	}

	// Gets the item from the given string key
	private Item GetItemFromKey(string itemKey) {
		return ItemDatabase.Instance.GetItem (itemKey);
	}

}
