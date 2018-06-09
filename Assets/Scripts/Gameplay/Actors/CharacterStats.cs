using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {

	public List<BaseStat> stats = new List<BaseStat>();

	public CharacterStats(int hitPoints, int speed, int strength) 
	{
		stats = new List<BaseStat> () { 
			new BaseStat(BaseStat.Type.HP, hitPoints, "HP", "Hit Points"),
			new BaseStat(BaseStat.Type.Speed, speed, "Speed", "Movement Speed"),
			new BaseStat(BaseStat.Type.Speed, strength, "Strength", "Attack Speed")
		};
	}

	public BaseStat GetStat(BaseStat.Type type) {
		BaseStat result;
		result = stats.Find (x => x.StatType == type);
		if (result == null) {
			Debug.LogError ("Character stat not found");
		}
		return result;
	}

}
