using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item {

	public enum Type { Weapon, Quest };

	public string key { get; set; }
	public string itemName;
	public string description;

	[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))
	public Type itemType;
	public string ActionName;


	public Item(string key) {
		this.key = key;
	}

	[Newtonsoft.Json.JsonConstructor]
	public Item(string key, 
		string itemName, 
		string description, 
		Type type,
			string ActionName) 
	{
		this.key = key;
		this.itemName = itemName;
		this.description = description;
		this.itemType = type;
		this.ActionName = ActionName;
	}
}
