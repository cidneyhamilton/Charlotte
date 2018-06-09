using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {

	public enum Type { HP, Speed, Strength }

	public Type StatType { get; set; }
	public int BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDescription { get; set; }

	public BaseStat(Type statType, int baseValue, string name, string description) {
		this.StatType = StatType;
		this.BaseValue = baseValue;
		this.StatName = name;
		this.StatDescription = description;
	}

}
