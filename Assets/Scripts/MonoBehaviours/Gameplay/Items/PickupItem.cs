using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public ReactionCollection reactions;

    public override void Interact() {

        // TODO: Make generic
        DialogManager.Instance.SayText ("Alexander, we are transferring the hostages to you at the cave tomorrow at noon. Yours, C.");
        Destroy(gameObject);
    }
}
