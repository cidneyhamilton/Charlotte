using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Charlotte {
    
    public class Bite : MonoBehaviour, IWeapon {
		
	public int damage = 1;
	private Animator animator;
	
	public void Start() {
	    animator = GetComponent<Animator> ();
	}
	
	public void PerformAttack() {
	    animator.SetTrigger ("Base Attack");
	}
	
	
	
	void OnTriggerEnter(Collider target) {
	    if (gameObject.tag == "Enemy" && target.tag == "Player") {
		Player player = (Player) target.GetComponent<Player> ();
		if (player == null) {
		    Debug.LogWarning("Player object can't be found.");
		} else {
		    player.TakeDamage (damage); 
		}        
	    }
	}
    }
}
