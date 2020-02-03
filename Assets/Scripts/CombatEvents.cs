using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {
    
    public class CombatEvents {
	
	public delegate void EnemyEventHandler();
	public static event EnemyEventHandler OnEnemyDeath;

	public delegate void OnPlayerHealthDelegate(int currentHealth);
	public static event OnPlayerHealthDelegate OnPlayerHealthUpdate;
	
	public static void EnemyDied()
	{
	    if (OnEnemyDeath != null)
		OnEnemyDeath();
	}

	public static void PlayerHealthUpdate(int currentHealth) {
	    if (OnPlayerHealthUpdate != null) {
		OnPlayerHealthUpdate(currentHealth);
	    }
	}
    }
}
