using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour {

	public Item item;

	public void SetItem(Item item) {
		Debug.Log ("Setting item " + item.itemName);
		this.item = item;
		this.SetupItemValues ();
	}

	private void SetupItemValues() {
		this.transform.Find ("Item_Name").GetComponent<Text> ().text = item.itemName;
		this.transform.Find("Item_Icon").GetComponent<Image>().sprite = Resources.Load<Sprite> ("UI/Icons/" + item.key);
	}

	public void OnSelectItem() {
		Debug.Log ("Selecting item {0} to display details");
		InventoryDetailView.Instance.SetItem (this.item, this.GetComponent<Button>());
	}
}
