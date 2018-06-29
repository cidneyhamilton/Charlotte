using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alexander : Bandit {

    public PickupItem loot;

    void Start() {
        base.Start();
        onDeath += DropLoot;
    }

	void DropLoot() {
        PickupItem instance = Instantiate(loot, transform.position, Quaternion.identity);
    }
}
