using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Lootable : MonoBehaviour {

	// What item is getting picked up?
    public PickupItem loot;

    void Start() {
        GetComponent<Character>().onDeath += DropLoot;
    }

	void DropLoot() {
        PickupItem instance = Instantiate(loot, transform.position, Quaternion.identity);
    }
}
