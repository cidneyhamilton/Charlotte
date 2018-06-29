using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Hostile, IEnemy {
    
    public Bite mouth;

    public void PerformAttack() {
        mouth.PerformAttack ();
    }

}
