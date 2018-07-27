using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : Singleton<AudioController> {

	// Sound effect played when picking up an item
	public AudioClip PickupSFX;

	public void PickupItem() {
		GetComponent<AudioSource>().PlayOneShot(PickupSFX, 0.2f);
	}
}
