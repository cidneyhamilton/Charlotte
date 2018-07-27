public class BaseStat {

	public enum BaseStatType { HP, Speed, Strength }

	public BaseStatType StatType { get; set; }
	public int BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDescription { get; set; }

	public BaseStat(BaseStatType statType, int baseValue, string name, string description) {
		this.StatType = statType;
		this.BaseValue = baseValue;
		this.StatName = name;
		this.StatDescription = description;
	}

}
