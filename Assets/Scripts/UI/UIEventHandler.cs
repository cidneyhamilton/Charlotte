using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : Singleton<UIEventHandler> {
	
	public delegate void ItemEventHandler(Item item);
	public static event ItemEventHandler OnAcquired;
	public static event ItemEventHandler OnUnacquired;
	public static event ItemEventHandler OnEquipped;
	public static event ItemEventHandler OnUnequipped;

	public static void Acquired(Item item) {
		if (OnAcquired != null) {
			OnAcquired (item);	
		}		
	}

	public static void Unacquired(Item item) {
		if (OnUnacquired != null) {
			OnUnacquired (item);
		}		
	}

	public static void Equipped(Item item) {
		if (OnEquipped != null) {
			OnEquipped (item);	
		}
	}

	public static void Unequipped(Item item) {
		if (OnUnequipped != null) {
			OnUnequipped (item);	
		}		

	}
}
