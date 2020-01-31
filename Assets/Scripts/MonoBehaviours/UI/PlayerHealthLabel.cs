using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Charlotte {
    
    [RequireComponent(typeof(Text))]
    public class PlayerHealthLabel : MonoBehaviour
    {
	
	Text label;
	
	void Start()
	{
	    // Initialize label
	    label = GetComponent<Text>();
	}
	
	void Update()
	{
	    // Update health label
	    Player player = GameObject.FindObjectOfType<Player>();
	    if (player != null) {
		label.text = "Health: " + player.currentHealth + "/" + player.maxHealth;
	    } else {
		label.text = "You are Dead";
	    }
	}
    }

}
