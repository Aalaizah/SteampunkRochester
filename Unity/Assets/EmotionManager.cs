using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmotionManager : MonoBehaviour {
	private List<string> characterName;
	private List<int> characterEmotion;
	//these prevent the emotions of a character from being changed a bunch of times per node
	private bool alreadyChangedUp;
	private bool alreadyChangedDwn;
	//our emotion emitters
	private GameObject happyFx;
	private GameObject sadFx;
	// Use this for initialization
	void Start () {
		characterName = new List<string>();
		characterEmotion = new List<int>();
		alreadyChangedUp = false;
		alreadyChangedDwn = false;
		var happy = Resources.Load("Particles/HappyFx");
		var sad = Resources.Load("Particles/SadFx");
		happyFx = Object.Instantiate(happy) as GameObject;
		sadFx = Object.Instantiate(sad) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	//takes in the person to update and whether to make them happier or angrier
	public void updateEmotions(string person, bool upOrDown)
	{
		//Debug.Log("updating Emotions of " + person + " " + upOrDown);
		//adds the person to the dictionary if they haven't been added yet
		//Debug.Log(characterName.Contains(person));
		if(!characterName.Contains(person))
		{
			characterName.Add(person);
			characterEmotion.Add(0);
		}
		
		//adds or subtracts from the value as per the boolean parameter
		if(upOrDown && !alreadyChangedUp){
			Debug.Log("GoingUp!");
			characterEmotion[characterName.IndexOf(person)]++;
			//trigger happy emoticon
			happyFx.particleSystem.Play();
			alreadyChangedUp = true;
		}
		else if(!upOrDown && !alreadyChangedDwn){
			characterEmotion[characterName.IndexOf(person)]--;
			//trigger sad emoticon
			sadFx.particleSystem.Play();
			alreadyChangedDwn = true;
		}
		
		//clamps the value to between -10 and 10
		if(characterEmotion[characterName.IndexOf(person)] > 10)
		{
			characterEmotion[characterName.IndexOf(person)] = 10;
		}
		else if(characterEmotion[characterName.IndexOf(person)] < -10)
		{
			characterEmotion[characterName.IndexOf(person)] = -10;
		}
		
		
	}
	void triggerEmotionParticle(GameObject particles)
	{
		var dialogue = GameObject.Find("DialogueScreen");
		if(dialogue != null)
		{
			//particles.transform.position = 
		}
	}
	
	//checks if the player has the correct relationship with the NPC
	public bool hasRequirement(string person, int req){
		for(int i=0; i < characterName.Count; i++)
		{
			Debug.Log("List: "  + characterName[i] + "! person: " + person + "!");
			Debug.Log(characterName[i].Equals(person));
			if(characterName[i] == person)
			{
				if(characterEmotion[i] >= req){
					return true;
				}
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
