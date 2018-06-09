using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Thug : Bandit, IEnemy {

	protected override void Start() {
		base.Start ();
		weaponController.EquipWeapon (new Item("longsword"));
		this.stats = new CharacterStats (2, 6, 2);
	}


}
