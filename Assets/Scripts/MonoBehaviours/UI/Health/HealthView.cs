using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {

    public abstract class HealthView : MonoBehaviour
    {
	
	void OnEnable() {
	    CombatEvents.OnPlayerHealthUpdate += UpdateHealth;
	}

	void OnDisable() {
	    CombatEvents.OnPlayerHealthUpdate -= UpdateHealth;
	}

	protected abstract void UpdateHealth(int currentHealth);	    
    }
}
