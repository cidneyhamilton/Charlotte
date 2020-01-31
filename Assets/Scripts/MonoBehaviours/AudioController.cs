using UnityEngine;

using Cyborg.Audio;

namespace Charlotte {
    
    public class AudioController : Singleton<AudioController> {
	
	public void PickupItem() {
	    AudioEvents.PlaySound("pickup_item");
	}
    }
}
