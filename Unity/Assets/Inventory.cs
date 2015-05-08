using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory:MonoBehaviour{
	//carries the information for what the player has had in their inventory and a bool for if it is currently in the inventory
	private Dictionary<string,bool> inventory;
	void Start(){
		inventory = new Dictionary<string, bool>();
	}
	
	void Update(){
	}
	//adds the item to the dictionary if it isn't already or makes sure that the item is set to true so that they currently have the item
	public void addItem(string item){
		Debug.Log("Adding item " + item);
		if(!inventory.ContainsKey(item)){
			inventory.Add(item,true);
		}
		else{
			inventory[item] = true;
		}
	}
	
	//removes the item from the inventory if they have it currently
	public void removeItem(string item){
		Debug.Log("Remove item " + item);
		if(inventory.ContainsKey(item)){
			inventory[item] = false;
		}
	}
	
	//checks to see if the player currently has an item in their inventory
	public bool hasItem(string item){
		if(inventory.ContainsKey(item)){
			return inventory[item];
		}
		return false;
	}
}
