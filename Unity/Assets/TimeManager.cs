using UnityEngine;
using System.Collections;

public class TimeManager:MonoBehaviour{

	private int minutes;//minutes of the time (goes up to 60)
	private int hours;//hours of time (goes up to 24)
	private string timeOfDay; //time of the day as a string; Morning, day, or night.
	void Start(){
		minutes = 0;
		hours = 18;
		timeOfDay = "Night";
	}

	void Update(){
	}
	//passes time by the passed in number of minutes
	public void passTime(int i)
	{
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
		}

		//checks what timeOfDay it is and sets the field appropriately
		if(hours < 11 && hours > 6)
			timeOfDay = "Morning";

		if(hours >= 11 && hours < 18)
			timeOfDay = "Day";
		if(hours >=18)
			timeOfDay = "Night";
	}
	//returns the time of day, can be changed to get the numbers if necessary
	public string getTime()
	{
		return timeOfDay;
	}
}
