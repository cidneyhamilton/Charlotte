using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {

	public List<BaseStat> stats = new List<BaseStat>();

	public CharacterStats(int hitPoints, int speed, int strength) 
	{
		stats = new List<BaseStat> () { 
			new BaseStat(BaseStat.BaseStatType.HP, hitPoints, "HP", "Hit Points"),
			new BaseStat(BaseStat.BaseStatType.Speed, speed, "Speed", "Movement Speed"),
			new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength", "Attack Speed")
		};
	}

	public BaseStat GetStat(BaseStat.BaseStatType stat) {
		BaseStat result;
		result = stats.Find (x => x.StatType == stat);
		if (result == null) {
			Debug.LogError ("Character stat not found");
		}
		return result;
	}

}
