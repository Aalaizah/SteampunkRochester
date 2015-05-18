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
	//the parent panel of all time UI elements
	private GameObject watchUI;
	//the image of the watch face
	private GameObject watchFace;
	//the text that relays time
	private GameObject watchText;
	//the panel containing the watch
	private GameObject watchPanel;
	//an alpha to fade away the watch, updated in updateWatch()
	private float watchAlpha;
	private float timeDisplayDurationInSeconds = 6;
	private float timeDisplayCountdown;
	public static bool ending1Flag;
	public static bool ending2Flag;
	public TimeOfDay timeOfDay;
	//When the time of day changes we need to show/hide interactables,
	//disabled interactables cannot be found again so we will store any interactable we find, until it is destroyed
	public List<Interactable> interactables;

	void Start(){
		interactables = new List<Interactable>();
		day=0;
		minutes = 0;
		hours = 18;
		timeOfDay = TimeOfDay.MORNING;
		watchUI = GameObject.Find("TimeUI");
		watchText = GameObject.Find("TimeKeeper");
		watchFace = GameObject.Find("WatchFace");
		watchPanel = GameObject.Find("TimeDisplay");
		showWatch();
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

		//update 
		updateWatch();
	}

	void updateWatch()
	{
		if(watchText == null) return;
		//'watch' countdown
		timeDisplayCountdown -= Time.deltaTime;
		//update the watch
		if(timeDisplayCountdown > 0)
		{
			//calculate a slight transitioning alpha
			float progress = (timeDisplayCountdown / timeDisplayDurationInSeconds);
			//p * p makes it an exponential curve
			//x * 10 makes it stay full opacity until the end
			//min cuts that 10->0 into a 1->0, so it stays 1 for a long time
			float repeatFadeInOut = 4;
			watchAlpha = (Mathf.Sin(progress*Mathf.PI*repeatFadeInOut) + 1) / 2;// Mathf.Min(1, (progress * progress)*10);
			//fit the 0-1 alpha within a min-max range
			float minAlpha = 0.4f;
			float maxAlpha = 1.0f;
			float alphaRange = maxAlpha - minAlpha;
			watchAlpha = minAlpha + (watchAlpha * alphaRange);
			//find our timeKeeper and set its text to formatted time
			Text textComponent = watchText.GetComponent<Text>();
			if(textComponent != null)
			{
				textComponent.text = getFullTime();
				//make some nice colors
				Color morningColor = Color.yellow;
				Color dayColor = new Color32(20, 160, 204, 255);
				Color nightColor = new Color32(178, 18, 63, 255);
				//set our final color based on the time of day
				Color finalColor = Color.white;
				switch(timeOfDay)
				{
				case TimeOfDay.MORNING:
					finalColor = morningColor;
					break;
				case TimeOfDay.DAY:
					finalColor = dayColor;
					break;
				case TimeOfDay.NIGHT:
					finalColor = nightColor;
					break;
				}
				//apply alpha
				finalColor.a = applyRange(0.4f, 1.0f, watchAlpha);
				textComponent.color = finalColor;
			}
			//set the alpha of our watch face
			var face = watchFace.GetComponent<Image>();
			if(face != null)
			{
				Color color = Color.white;
				color.a = applyRange(0.5f, 1.0f, watchAlpha);
				face.color = color;
			}
			//set the alpha of the watch backing
			var backing = watchPanel.GetComponent<Image>();
			if(backing != null)
			{
				Color black = Color.black;
				// x * .6f so we have semi trasnsparent backing most of the time
				black.a = applyRange(0.2f, 0.6f, watchAlpha);
				backing.color = black;
			}
		}else
		{
			//hideWatch();
		}
	}
	void showWatch()
	{
		//reset our watch countdown
		timeDisplayCountdown = timeDisplayDurationInSeconds;
		//active the watch ui
		watchUI.SetActive(true);
	}
	void hideWatch()
	{
		timeDisplayCountdown = 0;
		watchUI.SetActive(false);
	}
	float applyRange(float min, float max, float unitValue)
	{
		float range = max - min;
		return min + unitValue * range;
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
		//so we can move backwards
		while(minutes < 0)
		{
			hours--;
			minutes+=60;
		}
		if(hours >= 24)
		{
			hours = 0;
			day++;
		}

		showWatch();
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
				internalUpdateInteractable(thing);
			}
		}
	}
	void internalUpdateInteractable(Interactable thing)
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
	public void UpdateInteractable(Interactable thing)
	{
		if(!interactables.Contains(thing))
			interactables.Add(thing);
		internalUpdateInteractable(thing);
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
		string amPm = (hours > 11 ? " pm" : " am");
		return (hourText + ":" + minuteText +amPm);
	}
}
