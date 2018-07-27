using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Lootable : MonoBehaviour {

	// What item is getting picked up?
    public PickupItem loot;

    void Start() {
    	// Add Drop Loot to the character's OnDeath function
        GetComponent<Character>().onDeath += DropLoot;
    }

	void DropLoot() {
        Instantiate(loot, transform.position, Quaternion.identity);
    }
}
