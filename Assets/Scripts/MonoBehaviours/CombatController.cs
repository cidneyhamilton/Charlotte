using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

	public delegate void EnemyEventHandler();
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied()
    {
        if (OnEnemyDeath != null)
            OnEnemyDeath();
	}
}
