using UnityEngine.AI;

public class Character : Interactable {

	protected CharacterStats stats;
	protected int currentHealth, maxHealth;
	protected NavMeshAgent navAgent;
	
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
