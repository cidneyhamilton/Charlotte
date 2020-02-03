using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Charlotte {
    
    [RequireComponent(typeof(Text))]
    public class PlayerHealthLabel : MonoBehaviour
    {
	
	Text label;
	
	void Start()
	{
	    // Initialize label
	    label = GetComponent<Text>();
	}

	void OnEnable() {
	    CombatEvents.OnPlayerHealthUpdate += UpdateHealth;
	}

	void OnDisable() {
	    CombatEvents.OnPlayerHealthUpdate -= UpdateHealth;
	}
	

	void UpdateHealth(int currentHealth) {
	    label.text = "Health: " + currentHealth + "/" + 10;
	}
    }

}
