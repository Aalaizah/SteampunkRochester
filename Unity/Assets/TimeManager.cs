using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TimeManager:MonoBehaviour{
	
	private int minutes;//minutes of the time (goes up to 60)
	private int hours;//hours of time (goes up to 24)
	private int day;
	private string timeOfDayText; //time of the day as a string; Morning, day, or night.
	public GameObject camera; 
	public GameObject timeOfDayUI;
	public static bool ending1Flag;
	public static bool ending2Flag;
	public TimeOfDay timeOfDay;
	public List<Interactable> interactables;

	void Start(){
		interactables = new List<Interactable>();
		day=0;
		minutes = 0;
		hours = 11;
		timeOfDay = TimeOfDay.MORNING;
		updateTimeOfDay();
	}
	
	void Update(){
		timeOfDayUI = GameObject.Find ("Time");
		if(timeOfDayUI){

			timeOfDayUI.GetComponent<Text>().text = timeOfDayText;

			if(camera!=null)
			{
				Camera cameraComponent = camera.GetComponent<Camera>();
				if(timeOfDayText == "Morning")
				{
					cameraComponent.backgroundColor = new Color(255.0f/255.0f,153.0f/255.0f,0.0f/255.0f);
				}
				else if(timeOfDayText == "Day")
				{
					cameraComponent.backgroundColor = new Color(0.0f/255.0f,171.0f/255.0f,255.0f/255.0f);
				}
				else if(timeOfDayText == "Night")
				{
					cameraComponent.backgroundColor = new Color(0.0f/255.0f,0.0f/255.0f,0.0f/255.0f);
				}
			}
		}
		//find our timeKeeper and set its text to formatted time
		GameObject watch = GameObject.Find("TimeKeeper");
		if(watch != null)
		{
			Text textComponent = watch.GetComponent<Text>();
			textComponent.text = getFullTime();
		}
	}
	//passes time by the passed in number of minutes
	public void passTime(int i)
	{
		Debug.Log("Passing " + i + " Minutes");
		minutes += i;
		//checks the limits of minutes and hours
		while(minutes >= 60)
		{
			hours++;
			minutes-=60;
		}
		if(hours >= 24)
		{
			hours = 0;
			day++;
		}

		updateTimeOfDay();
	}
	public void updateTimeOfDay()
	{
		//checks what timeOfDay it is and sets the field appropriately
		if(hours < 11 && hours > 6)
			timeOfDay = TimeOfDay.MORNING;
		if(hours >= 11 && hours < 18)
			timeOfDay = TimeOfDay.DAY;
		if(hours >=18)
			timeOfDay = TimeOfDay.NIGHT;

		switch(timeOfDay)
		{
		case TimeOfDay.MORNING:
			timeOfDayText = "Morning";
			break;
		case TimeOfDay.DAY:
			timeOfDayText = "Day";
			break;
		case TimeOfDay.NIGHT:
			timeOfDayText = "Night";
			break;
		}

		UpdateInteractables();
	}

	/// <summary>
	/// Go through all interactables and change their active state based on the time.
	/// </summary>
	void UpdateInteractables()
	{
		//find all current interactables
		var newInteractables = GameObject.FindObjectsOfType<Interactable>();
		foreach(var thing in newInteractables)
		{
			//add them to the interactable list if we dont already have it
			if(!interactables.Contains(thing))
				interactables.Add(thing);
		}
		//go through all our interactables now
		for(int i = 0; i < interactables.Count; ++i)
		{
			var thing = interactables[i];
			if(thing == null)
			{
				//remove null stuff
				interactables.RemoveAt(i);
				//decrement i so we dont skip over the thing at i
				--i;
			}
			else
			{
				//finally update the interactable
				updateInteractable(thing);
			}
		}
	}
	void updateInteractable(Interactable thing)
	{
		//this can be utilized but isnt yet
		if(thing.disableReactionToTime)
			return;
		//determine whether an interactable wants to appear during this timeOfDay
		bool active = false;
		switch(timeOfDay)
		{
		case TimeOfDay.MORNING:
			active = thing.appearsDuringMorning;
			break;
		case TimeOfDay.DAY:
			active = thing.appearsDuringDay;
			break;
		case TimeOfDay.NIGHT:
			active = thing.appearsDuringNight;
			break;
		}
		//find the parent of the core (it should have one)
		var parentT = thing.transform.parent;
		if(parentT != null)
		{
			//only change active state if neccessary (unity might do this anyway, not sure)
			if(parentT.gameObject.activeSelf != active)
			{
				parentT.gameObject.SetActive(active);
			}
		}
	}
	//returns the time of day, can be changed to get the numbers if necessary
	public string getTime()
	{
		return timeOfDayText;
	}

	public int getDay()
	{
		return day;
	}

	public string getFullTime()
	{
		//this aint the military, 12 hour system baby
		//% is exclusive
		int trueHours = hours % 12;
		//weird condition
		if(trueHours == 0)
			trueHours = 12;
		//ugly shorthand to add leading zeroes if the time is double digits
		string hourText = (trueHours < 10 ? "0" : "") + trueHours;
		string minuteText = (minutes < 10 ? "0" : "") + minutes;
		string amPm = hours > 11 ? " pm" : " am";
		return (getTime() + "\n" + hourText + ":" + minuteText +amPm);
	}
}
