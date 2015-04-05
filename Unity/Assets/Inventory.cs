using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Inventory{
	public static List<string> inventory = new List<string>();

	public static void addItem(string item){
		if(!inventory.Contains(item)){
			inventory.Add(item);
		}
	}
}
