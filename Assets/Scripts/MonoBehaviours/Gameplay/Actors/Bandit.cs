using UnityEngine;

public class Bandit : Character, IEnemy {

	public int Health = 2;
	public int Speed = 6;
	public int Strength = 2;

	protected WeaponController weaponController;
	private Player _player;

	public LayerMask aggroLayerMask;
	Collider[] withinAggroColliders;

	private const float SIGHT = 15f;
	private const float RANGE = 1f;

    void Awake() {
        stats = new CharacterStats (Health, Speed, Strength);
        weaponController = GetComponent<WeaponController> ();
        tag = "Enemy";
    }

    void OnEnable() {
        EquipWeapon();
    }

    void EquipWeapon() {
        if (Strength <= 2) {
            Debug.Log("Equipping shortsword.");
            weaponController.EquipWeapon (new Item("shortsword"));  
        } else {
            Debug.Log("Equipping longsword.");
            weaponController.EquipWeapon (new Item("longsword")); 
        }  
    }

	void FixedUpdate() {
		withinAggroColliders = Physics.OverlapSphere (transform.position, 
			SIGHT, 
			aggroLayerMask);
		if (withinAggroColliders.Length > 0) {
			ChasePlayer (withinAggroColliders[0].GetComponent<Player>());
		}
	}

	public void PerformAttack() {
		weaponController.PerformWeaponAttack ();
	}

	void ChasePlayer(Player player) {
		_player = player;
		navAgent.SetDestination (player.transform.position);

		// If we're close enough to attack, attack
		if (InRange ()) {
			navAgent.updatePosition = false;
			if (!IsInvoking ("PerformAttack")) {
				InvokeRepeating ("PerformAttack", 0.5f, 2f);
			}
		} else {
			navAgent.updatePosition = true;
		}
	}

	bool InRange() {
		Collider[] cols = Physics.OverlapSphere (transform.position, 
			RANGE, 
			aggroLayerMask);
		return cols.Length > 0;
	}

	public override void Interact() {
		MoveToInteraction (playerAgent);
	}
}
