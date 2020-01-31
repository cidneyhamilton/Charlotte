using UnityEngine;

namespace Charlotte {
    
    public class Player : Character {
	
	public Player Instance;
	public WeaponController weaponController;

	const string DeathMessage = "You have died!";

	void Awake () {
	    
	    // Make sure there is only one player in the game
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
	    StoryEvents.Say(DeathMessage);
	}
	
	void Update() {
	    if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
		weaponController.PerformWeaponAttack ();
	    }
	}
	
    }

}
