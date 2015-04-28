using UnityEngine;
using System.Collections;

public static class TimeManager{

	private static int minutes = 0;//minutes of the time (goes up to 60)
	private static int hours = 19;//hours of time (goes up to 24)
	private static string timeOfDay = "Night"; //time of the day as a string; Morning, day, or night.

	//passes time by the passed in number of minutes
	public static void passTime(int i)
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
	public static string getTime()
	{
		return timeOfDay;
	}

	public static int getMinutes()
	{
		return minutes;
	}

	public static string getFormattedTime()
	{
		int wrapHours = hours % 12;
		bool pm = hours >= 12;
		return "It is " + wrapHours + ":" + minutes + (pm ? " pm" : " am");
	}
}
