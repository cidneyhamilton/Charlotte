using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

	// Reference to the item being picked up
	public string itemName;

	// Reactions when picking up item
    public ReactionCollection reactions;

    public override void Interact() {

        // React when picking up the item
        reactions.React();

        // Update inventory with the item dropped
        InventoryController.Instance.AddItem(itemName);

        // Remove item from game world
        Destroy(gameObject);
    }
}
