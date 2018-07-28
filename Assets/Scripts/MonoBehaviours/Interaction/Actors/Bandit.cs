using UnityEngine;

public class Bandit : Hostile, IEnemy {

	protected WeaponController weaponController;

    public void PerformAttack() {
        weaponController.PerformWeaponAttack ();
    }

    protected void Awake() {
        weaponController = GetComponent<WeaponController> ();
        base.Awake();
    }

    void OnEnable() {
        EquipWeapon();
        onDeath += CombatController.EnemyDied;
    }



    void EquipWeapon() {
        if (Strength <= 2) {
            Debug.Log("Equipping shortsword.");
            weaponController.EquipWeapon (new Item("shortsword"));  
        } else {
            Debug.Log("Equipping longsword.");
            weaponController.EquipWeapon (new Item("longsword")); 
        }  
    }

}
