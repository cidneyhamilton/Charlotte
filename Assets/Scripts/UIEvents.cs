using System;
using UnityEngine;

namespace Charlotte {
    
    public class UIEvents 
    {
	public static Action OnHide;

	public static void Hide() {
	    if (OnHide != null) {
		OnHide();
	    }
	}
       
    }
}
    
