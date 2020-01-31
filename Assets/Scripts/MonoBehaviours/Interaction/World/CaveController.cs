using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

namespace Charlotte {
    
    public class CaveController : MonoBehaviour {
	
	public int numKilled = 0;
	public int numSpawned = 0;
	bool finalEncounterTriggered = false;
	
	public GameObject FinalEncounter;
	public GameObject FinalEncounterSpawnPoint;

	// The json compiled ink story
	public TextAsset OnEnteredStory;
	
	// The ink runtime story object
	private Story story;
	
	void Start() {
	    // Final enounter is saved for later
	    FinalEncounter.gameObject.SetActive(false);
	    
	    // Keep track of the number of monsters the player needs to kill to advance
	    numSpawned = GameObject.FindObjectsOfType<Bandit>().Length;
	    
	    CombatController.OnEnemyDeath += EnemyDied;
	    
	}
	
	void EnemyDied() {
	    numKilled++;
	    Evaluate();
	}
	
	void Evaluate() {
	    if (numKilled >= numSpawned && !finalEncounterTriggered) {
		// Trigger time change and final encounter
		finalEncounterTriggered = true;
		AdvanceTime();
	    }
	}
	
	void AdvanceTime() {
	    // Fade to black
	    
	    // Time advances to evening
	    
	    // Move player towards the entrance
	    Player hero = GameObject.FindObjectOfType<Player>();
	    hero.transform.SetPositionAndRotation(FinalEncounterSpawnPoint.transform.position, Quaternion.identity);
	    
	    // Final set of bandits enter
	    FinalEncounter.gameObject.SetActive(true);
	    
	    // Fade In
	    
	    
	    // Dialogue
	    story = new Story(OnEnteredStory.text);
	    DialogManager.Instance.BeginStory(story);
	}
	
    }
}
