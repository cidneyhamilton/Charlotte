using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectile  {

	private Animator animator;
	public int damage = 2;

	public Transform ProjectileSpawn { get; set; }
	Fireball fireball;

	public void Start() {
		animator = this.GetComponent<Animator> ();
		fireball = Resources.Load<Fireball> ("Weapons/Projectiles/Fireball");

	}

	public void PerformAttack() {
		animator.SetTrigger ("Base Attack");
	}

	public void CastProjectile() {
		Fireball fireballInstance = (Fireball) Instantiate (fireball, ProjectileSpawn.position, this.transform.rotation);
		fireballInstance.Direction = ProjectileSpawn.forward;
			
	}
		
}
