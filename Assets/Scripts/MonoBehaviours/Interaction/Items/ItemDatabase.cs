using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : Singleton<ItemDatabase> {

	private List<Item> Items { get; set; }

	// Take JSON data and build a list of items
	private void BuildDatabase() {
		string inventoryJSON = Resources.Load<TextAsset> ("JSON/items").ToString ();
		this.Items = JsonConvert.DeserializeObject<List<Item>> (inventoryJSON);
	}

	public Item GetItem(string key) {
		if (this.Items == null) {
			this.BuildDatabase ();
		}

		foreach (Item item in this.Items) {
			if (item.key == key) {
				return item;
			}
		}

		// No item returned
		Debug.LogWarning("No item found matching key " + key);
		return null;
	}

}
