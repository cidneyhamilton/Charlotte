using UnityEngine.AI;

public class Character : Interactable {

	protected CharacterStats stats;
	protected int currentHealth, maxHealth;
	protected NavMeshAgent navAgent;
		
	protected virtual void Start() {
		currentHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
		maxHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
		SetSpeed();
	}

	protected void SetSpeed() {
		// Set NavAgent speed
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.speed = stats.GetStat(BaseStat.BaseStatType.Speed).BaseValue * 20;
		navAgent.angularSpeed = stats.GetStat(BaseStat.BaseStatType.Speed).BaseValue * 40;
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
