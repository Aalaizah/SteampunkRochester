using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EmotionManager{
	//one intialize
	static bool initialized;
	//dictionary to contain the characters and their respecitve happiness towards the player character
	private static Dictionary<string,int> emotionValue = new Dictionary<string,int>();
	private static bool alreadyChangedUp = false;
	private static bool alreadyChangedDwn = false;
	//our emotion emitters
	private static GameObject happyFx;
	private static GameObject sadFx;

	//Initializes only if its not already done
	public static bool TryInitialize()
	{
		if(initialized)
			return false;
		var happy = Resources.Load("Particles/HappyFx");
		var sad = Resources.Load("Particles/SadFx");
		Debug.Log(happy);
		Debug.Log(sad);
		happyFx = Object.Instantiate(happy) as GameObject;
		sadFx = Object.Instantiate(sad) as GameObject;
		initialized = true;
		return true;
	}

	//takes in the person to update and whether to make them happier or angrier
	public static void updateEmotions(string person, bool upOrDown)
	{
		TryInitialize();

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

	public static bool hasRequirement(string person, int req){
		if(emotionValue.ContainsKey(person))
		{
			if(emotionValue[person] >= req){
				return true;
			}
		}
		return false;
	}

	public static void resetBooleans(){
		alreadyChangedUp = false;
		alreadyChangedDwn = false;
	}

}
