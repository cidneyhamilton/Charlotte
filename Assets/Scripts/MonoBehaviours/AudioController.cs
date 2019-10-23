using UnityEngine;

using Cyborg.Audio;

public class AudioController : Singleton<AudioController> {

	public void PickupItem() {
		AudioEvents.PlaySound("pickup_item");
	}
}
