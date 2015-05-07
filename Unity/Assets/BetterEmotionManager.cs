using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BetterEmotionManager : MonoBehaviour {
	private Dictionary<string,int> emotionValue;
	//these prevent the emotions of a character from being changed a bunch of times per node
	private bool alreadyChangedUp;
	private bool alreadyChangedDwn;
	//our emotion emitters
	private GameObject happyFx;
	private GameObject sadFx;
	
	void Start(){
		emotionValue = new Dictionary<string,int>();
		alreadyChangedUp = false;
		alreadyChangedDwn = false;
		var happy = Resources.Load("Particles/HappyFx");
		var sad = Resources.Load("Particles/SadFx");
		happyFx = Object.Instantiate(happy) as GameObject;
		sadFx = Object.Instantiate(sad) as GameObject;
	}
	
	void Update(){
	}
	
	//takes in the person to update and whether to make them happier or angrier
	public void updateEmotions(string person, bool upOrDown)
	{
		
		//adds the person to the dictionary if they haven't been added yet
		if(!emotionValue.ContainsKey(person))
		{
			emotionValue.Add(person,0);
		}
		
		//adds or subtracts from the value as per the boolean parameter
		if(upOrDown && !alreadyChangedUp){
			emotionValue[person]++;
			//trigger happy emoticon
			happyFx.particleSystem.Play();
			alreadyChangedUp = true;
		}
		else if(!upOrDown && !alreadyChangedDwn){
			emotionValue[person]--;
			//trigger sad emoticon
			sadFx.particleSystem.Play();
			alreadyChangedDwn = true;
		}
		
		//clamps the value to between -10 and 10
		if(emotionValue[person] > 10)
		{
			emotionValue[person] = 10;
		}
		else if(emotionValue[person] < -10)
		{
			emotionValue[person] = -10;
		}
		
		
	}
	
	//checks if the player has the correct relationship with the NPC
	public bool hasRequirement(string person, int req){
		if(emotionValue.ContainsKey(person))
		{
			if(emotionValue[person] >= req){
				return true;
			}
		}
		return false;
	}
	
	//resets the booleans controlling for when the emotions will be updated
	public void resetBooleans(){
		alreadyChangedUp = false;
		alreadyChangedDwn = false;
	}
}
