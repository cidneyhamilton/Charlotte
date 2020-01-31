using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {
    
    public class PickupItem : Interactable {
	
    // Reference to the item being picked up
	public string itemName;
	
	public override void Interact() {
	    Debug.Log("Item picked up.");
	    
	    // Play pickup sound effect
	    AudioController.Instance.PickupItem();
	    
	    // Update inventory with the item dropped
	    InventoryController.Instance.AddItem(itemName);
	    
	    // Remove item from game world
	    Destroy(gameObject);
	}
    }
}
