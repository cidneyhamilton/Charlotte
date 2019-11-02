using UnityEngine.AI;

public class Character : Interactable {

	// For combat
	protected CharacterStats stats;
	public int currentHealth, maxHealth;

	// For movement
	protected NavMeshAgent navAgent;

	// Callback to spawn loot, or perform an action, when the character dies
	public delegate void OnDeath();
	public event OnDeath onDeath;
	
    public void Stop() {
        navAgent.destination = transform.position;
    }	

	protected virtual void Start() {
		currentHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
		maxHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
		SetSpeed();
	}

	protected void SetSpeed() {
		// Set NavAgent speed
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.speed = stats.GetStat(BaseStat.BaseStatType.Speed).BaseValue;
	}

	// Damage the character by the given amount
	public void TakeDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= amount) {
			Die ();
		}
	}

	public virtual void Die() {
		if (onDeath != null) {
			onDeath();
		}
		Destroy(gameObject);
	}
}
