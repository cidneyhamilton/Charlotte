using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject hand;
	public GameObject EquippedWeapon { get; set; }

	Transform spawnProjectile; 
	IWeapon equippedWeapon;

	void Start() {
		spawnProjectile = transform.Find ("ProjectileSpawn");
	}

	public void EquipWeapon(Item itemToEquip) {
		UnequipWeapon ();

		GameObject weapon = GetWeaponByKey(itemToEquip.key);
		if (weapon == null) {
			Debug.LogError("Weapon with key " + itemToEquip.key + " not found.");
			return;
		}
		EquippedWeapon = (GameObject) Instantiate (weapon);
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon> ();

		// TODO: Check the item type of the weapon
		if (EquippedWeapon.GetComponent<IProjectile> () != null) {
			Debug.Log ("Set Projectile Spawn");
			EquippedWeapon.GetComponent<IProjectile> ().ProjectileSpawn = spawnProjectile;
		}

		EquippedWeapon.transform.SetParent (hand.transform, false);
		EquippedWeapon.tag = tag;
	}

	private GameObject GetWeaponByKey(string key) {
		return Resources.Load<GameObject>("Weapons/" + key);
	}

	public void PerformWeaponAttack() {
		if (EquippedWeapon != null) {
			equippedWeapon.PerformAttack ();
		} else {
			Debug.Log("Can't attack; no weapon equipped.");
		}
	}

	public void UnequipWeapon() {
		if (EquippedWeapon != null) {
			Destroy (hand.transform.GetChild (0).gameObject);
		}
	}
}
