using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Inventory{
	//carries the information for what the player has had in their inventory and a bool for if it is currently in the inventory
	private static Dictionary<string,bool> inventory = new Dictionary<string, bool>();

	//adds the item to the dictionary if it isn't already or makes sure that the item is set to true so that they currently have the item
	public static void addItem(string item){
		if(!inventory.ContainsKey(item)){
			inventory.Add(item,true);
		}
		else{
			inventory[item] = true;
		}
	}

	//removes the item from the inventory if they have it currently
	public static void removeItem(string item){
		if(inventory.ContainsKey(item)){
			inventory[item] = false;
		}
	}

	//checks to see if the player currently has an item in their inventory
	public static bool hasItem(string item){
		if(inventory.ContainsKey(item)){
			return inventory[item];
		}
		return false;
	}
}
