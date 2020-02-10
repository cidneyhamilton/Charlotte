using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {

    public class HealthRadial : HealthView
    {

	// TODO: Define in one place
	const int maxHealth = 10;	

	protected override void UpdateHealth(int currentHealth) {
	    float zAngle = 180f * currentHealth / maxHealth;
	    transform.Rotate(0, 0, zAngle);
	}
    }
}
