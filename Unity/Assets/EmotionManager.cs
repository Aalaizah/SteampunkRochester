using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EmotionManager{
	//dictionary to contain the characters and their respecitve happiness towards the player character
	private static Dictionary<string,int> emotionValue = new Dictionary<string,int>();
	//these prevent the emotions of a character from being changed a bunch of times per node
	private static bool alreadyChangedUp = false;
	private static bool alreadyChangedDwn = false;

	//takes in the person to update and whether to make them happier or angrier
	public static void updateEmotions(string person, bool upOrDown)
	{
		//adds the person to the dictionary if they haven't been added yet
		if(!emotionValue.ContainsKey(person))
		{
			emotionValue.Add(person,0);
		}

		//adds or subtracts from the value as per the boolean parameter
		if(upOrDown && !alreadyChangedUp){
			emotionValue[person]++;
			alreadyChangedUp = true;
		}
		else if(!upOrDown && !alreadyChangedDwn){
			emotionValue[person]--;
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
	public static bool hasRequirement(string person, int req){
		if(emotionValue.ContainsKey(person))
		{
			if(emotionValue[person] >= req){
				return true;
			}
		}
		return false;
	}

	//resets the booleans controlling for when the emotions will be updated
	public static void resetBooleans(){
		alreadyChangedUp = false;
		alreadyChangedDwn = false;
	}

}
