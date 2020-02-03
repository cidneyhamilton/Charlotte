﻿using UnityEngine;
using UnityEngine.AI;

namespace Charlotte {
    
    public class Character : Interactable {
	
	// For combat
	protected CharacterStats stats;
	public int currentHealth, maxHealth;

	// For movement
	protected NavMeshAgent navAgent;
	
	// Callback to spawn loot, or perform an action, when the character dies
	public delegate void OnDeath();
	public event OnDeath onDeath;

	private AudioSource audio;
	public AudioClip hit;
	public AudioClip death;
	
	public void Stop() {
	    navAgent.destination = transform.position;
	}	
	
	protected virtual void Start() {
	    currentHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
	    maxHealth = stats.GetStat (BaseStat.BaseStatType.HP).BaseValue;
	    SetSpeed();

	    audio = GetComponent<AudioSource>();
	}
	
	protected void SetSpeed() {
	    // Set NavAgent speed
	    navAgent = GetComponent<NavMeshAgent> ();
	    navAgent.speed = stats.GetStat(BaseStat.BaseStatType.Speed).BaseValue;
	}
	
	// Damage the character by the given amount
	public virtual void TakeDamage(int amount) {

	    PlayHitSFX();	
	    currentHealth -= amount;
	    if (currentHealth <= amount) {
		PlayDeathSFX();
		Die ();
	    }
	}

	public virtual void Die() {
	    if (onDeath != null) {
		onDeath();
	    }
	    
	    Destroy(gameObject);
	}
	
	void PlayHitSFX() {
	    if (audio) {
		audio.clip = hit;
		audio.Play();
	    };
	}

	void PlayDeathSFX() {
	    if (audio) {
		audio.clip = death;
		audio.Play();
	    };
	}

    }
}
