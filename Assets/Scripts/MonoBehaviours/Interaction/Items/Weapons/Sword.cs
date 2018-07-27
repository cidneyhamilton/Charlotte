using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour, IWeapon {

	private Animator animator;
	public int damage = 4;

	public void Start() {
		animator = GetComponent<Animator> ();
	}

	public void PerformAttack() {
		animator.SetTrigger ("Base Attack");
	}

	void OnTriggerEnter(Collider target) {
		// Deal damage
		if (gameObject.tag == "Player" && target.tag == "Enemy") {
			IEnemy enemy = target.GetComponent<IEnemy>();
			if (enemy == null) {
				Debug.LogWarning("Enemy object can't be found.");
			} else {
				enemy.TakeDamage(damage);	
			}	
		} else if (gameObject.tag == "Enemy" && target.tag == "Player") {
			Player player = (Player) target.GetComponent<Player> ();
			if (player == null) {
				Debug.LogWarning("Player object can't be found.");
			} else {
				player.TakeDamage (damage);	
			}
			
		}
	}
}
