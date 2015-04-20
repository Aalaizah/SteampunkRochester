using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Inventory{
	private static Dictionary<string,bool> inventory = new Dictionary<string, bool>();

	public static void addItem(string item){
		if(!inventory.ContainsKey(item)){
			inventory.Add(item,true);
		}
		else{
			inventory[item] = true;
		}
	}

	public static void removeItem(string item){
		if(inventory.ContainsKey(item)){
			inventory[item] = false;
		}
	}

	public static bool hasItem(string item){
		if(inventory.ContainsKey(item)){
			return inventory[item];
		}
		return false;
	}
}
