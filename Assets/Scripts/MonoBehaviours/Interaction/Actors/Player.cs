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

	public bool IsWounded() {
		return currentHealth < maxHealth;
	}

	protected override void Start() {
		tag = "Player";
		weaponController = GetComponent<WeaponController> ();
		// Player starts with a longsword
		weaponController.EquipWeapon(new Item("longsword"));
		stats = new CharacterStats (10, 10, 4);
		base.Start();

        onDeath += PlayerDeath;
	}

	protected void PlayerDeath() {
        // TODO: Move to Game Manager
        Time.timeScale = 0;
		DialogManager.Instance.SayText("You have died!");
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
			weaponController.PerformWeaponAttack ();
		}
	}

}
