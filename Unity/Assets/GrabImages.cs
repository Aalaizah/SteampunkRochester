using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GrabImages : MonoBehaviour {
	Inventory theInv;
	public Sprite pin;
	public Sprite glowingBottle;
	public Sprite glowingWater;
	public Sprite emptyBottle;
	public Sprite waterBottle;
	public Sprite businessCard;
	public Sprite alcohol;
	// Use this for initialization
	void Start () {
		theInv = GameObject.Find("SystemManager").GetComponent<Inventory>();
		List<string> myList = theInv.getAllCurrItems();
		GameObject[] allItemBoxes = GameObject.FindGameObjectsWithTag("ItemInUI");
		foreach(string s in myList){
			for(int i=0; i < allItemBoxes.Length; i++)
			{
				if(allItemBoxes[i].GetComponent<Image>().sprite == null)
				{
					if(s == "PIN")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = pin;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "GLOWINGBOTTLE")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = glowingBottle;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "BOTTLEGLOWINGWATER")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = glowingWater;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "BOTTLEEMPTY")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = emptyBottle;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "BOTTLEWATER")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = waterBottle;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "BUSINESSCARD")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = businessCard;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
					else if(s == "ALCOHOL")
					{
						allItemBoxes[i].GetComponent<Image>().sprite = alcohol;
						allItemBoxes[i].GetComponent<Image>().color = Color.white;
						break;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
