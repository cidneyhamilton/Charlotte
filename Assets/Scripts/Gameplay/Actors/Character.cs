public class Character : Interactable {

	public CharacterStats stats;

	public int currentHealth, maxHealth;
		
	protected virtual void Start() {
		currentHealth = stats.GetStat (BaseStat.Type.HP).BaseValue;
		maxHealth = stats.GetStat (BaseStat.Type.HP).BaseValue;
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= amount) {
			Die ();
		}
	}

	public virtual void Die() {
		// TODO: Kill the enemy and replace with a corpse
		Destroy(gameObject);
	}
}
