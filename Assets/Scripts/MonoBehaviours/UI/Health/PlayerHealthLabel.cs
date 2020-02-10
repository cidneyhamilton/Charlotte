using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Charlotte {
    
    [RequireComponent(typeof(Text))]
    public class PlayerHealthLabel : HealthView
    {
	
	Text label;
	
	void Start()
	{
	    // Initialize label
	    label = GetComponent<Text>();
	}
	
	protected override void UpdateHealth(int currentHealth) {
	    label.text = "Health: " + currentHealth + "/" + 10;
	}
    }

}
