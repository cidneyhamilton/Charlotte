using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public Vector3 Direction { get; set; }
	public float range { get; set; }
	public int Damage { get; set; }

	Vector3 SpawnPosition { get; set; }
	void Start() {
		this.range = 20f;
		this.Damage = 2;
		this.SpawnPosition = transform.position;
		this.GetComponent<Rigidbody> ().AddForce (Direction * 100f);
	}

	void Update() {
		if (IsOutOfRange()) {
			Destroy (this.gameObject);
		}
	}

	bool IsOutOfRange() {
		return Vector3.Distance (SpawnPosition, transform.position) >= range;
	}

	void OnCollisionEnter(Collision col) {
		if (col.transform.tag == "Enemy") {
			col.transform.GetComponent<IEnemy> ().TakeDamage (this.Damage);

		} 
		//Destroy (this.gameObject);
	}
}
