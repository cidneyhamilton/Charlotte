using UnityEngine;

public class Player : Character {

	public Player Instance;
	public WeaponController weaponController;

	void Awake () {
		if (Instance != null && !Instance == this) {
			Destroy(gameObject);
		} else {
			Instance = this;
		}
	}

	protected override void Start() {
		tag = "Player";
		weaponController = GetComponent<WeaponController> ();
		// Player starts with a longsword
		weaponController.EquipWeapon(new Item("longsword"));
		stats = new CharacterStats (10, 10, 4);
		base.Start();
	}

	public override void Die() {
		// Player is dead. Reset health
		base.Die();	
		DialogManager.Instance.AddNewDialogue("You have died! GAME OVER.");	
		Time.timeScale = 0;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
			weaponController.PerformWeaponAttack ();
		}
	}

}
