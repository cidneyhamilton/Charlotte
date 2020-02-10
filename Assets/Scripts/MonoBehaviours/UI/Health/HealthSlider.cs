using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Charlotte {

    [RequireComponent(typeof(Slider))]
    public class HealthSlider : HealthView
    {

	Slider slider;
	
	void Start() {
	    slider = GetComponent<Slider>();

	    // TODO: Dynamically set max health
	    slider.value = 10;
	}


	protected override void UpdateHealth(int currentHealth) {
	    slider.value = currentHealth;	    
	}
    }
}
