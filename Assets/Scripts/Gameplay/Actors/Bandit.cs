using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bandit : Character, IEnemy {

	protected WeaponController weaponController;
	private NavMeshAgent navAgent;
	Player player;

	public LayerMask aggroLayerMask;
	Collider[] withinAggroColliders;

	private float sight = 15f;
	private float range = 1f;

	protected override void Start() {
		this.navAgent = GetComponent<NavMeshAgent> ();
		this.stats = new CharacterStats (2, 6, 2);
		this.tag = "Enemy";
		this.weaponController = this.GetComponent<WeaponController> ();
		this.weaponController.EquipWeapon (new Item("shortsword"));
	}

	void FixedUpdate() {
		withinAggroColliders = Physics.OverlapSphere (this.transform.position, 
			sight, 
			aggroLayerMask);
		if (withinAggroColliders.Length > 0) {
			ChasePlayer (withinAggroColliders[0].GetComponent<Player>());
		}
	}

	public void PerformAttack() {
		weaponController.PerformWeaponAttack ();
		Debug.Log ("Bandit attacking");
	}


	void ChasePlayer(Player player) {
		this.player = player;
		navAgent.SetDestination (player.transform.position);

		// If we're close enough to attack, attack
		if (InRange ()) {
			this.navAgent.updatePosition = false;
			if (!IsInvoking ("PerformAttack")) {
				InvokeRepeating ("PerformAttack", 0.5f, 2f);
			} else {
				//CancelInvoke ();
			}
		} else {
			this.navAgent.updatePosition = true;
		}
	}

	bool InRange() {
		Collider[] cols = Physics.OverlapSphere (this.transform.position, 
			range, 
			aggroLayerMask);
		return cols.Length > 0;
	}

	public override void Die() {
		// TODO: Kill the enemy and replace with a corpse
		Destroy(this.gameObject);
	}

	public override void Interact() {
		MoveToInteraction (this.playerAgent);
	}
}
