using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {
    
    public class CombatEvents {
	
	public delegate void EnemyEventHandler();
	public static event EnemyEventHandler OnEnemyDeath;
	
	public static void EnemyDied()
	{
	    if (OnEnemyDeath != null)
		OnEnemyDeath();
	}
    }
}
