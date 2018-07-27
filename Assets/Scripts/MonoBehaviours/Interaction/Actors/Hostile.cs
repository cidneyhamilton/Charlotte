using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile : Character {

    public int Health = 2;
    public int Speed = 4;
    public int Strength = 2;

    protected Player _player;

    public LayerMask aggroLayerMask;
    Collider[] withinAggroColliders;

    protected const float SIGHT = 15f;
    protected const float RANGE = 1f;

    protected void Awake() {
        stats = new CharacterStats (Health, Speed, Strength);
        tag = "Enemy";
    }
	
	void FixedUpdate() {
        withinAggroColliders = Physics.OverlapSphere (transform.position, 
            SIGHT, 
            aggroLayerMask);
        if (withinAggroColliders.Length > 0) {
            ChasePlayer (withinAggroColliders[0].GetComponent<Player>());
        }
    }

    void ChasePlayer(Player player) {
        _player = player;
        navAgent.SetDestination (player.transform.position);

        // If we're close enough to attack, attack
        if (InRange ()) {
            navAgent.updatePosition = false;
            if (!IsInvoking ("PerformAttack")) {
                InvokeRepeating ("PerformAttack", 0.5f, 2f);
            }
        } else {
            navAgent.updatePosition = true;
        }
    }

    bool InRange() {
        Collider[] cols = Physics.OverlapSphere (transform.position, 
            RANGE, 
            aggroLayerMask);
        return cols.Length > 0;
    }

    public override void Interact() {
        MoveToInteraction (playerAgent);
    }

}
