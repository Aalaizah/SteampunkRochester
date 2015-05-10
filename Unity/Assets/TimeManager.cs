using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager:MonoBehaviour{
	
	private int minutes;//minutes of the time (goes up to 60)
	private int hours;//hours of time (goes up to 24)
	private int day;
	private string timeOfDay; //time of the day as a string; Morning, day, or night.
	public GameObject camera; 
	public GameObject timeOfDayUI;
	public static bool ending1Flag;
	public static bool ending2Flag;

	void Start(){
		day=1;
		minutes = 0;
		hours = 22;
		timeOfDay = "Night";

	}
	
	void Update(){
		timeOfDayUI = GameObject.Find ("Time");
		if(timeOfDayUI){

			timeOfDayUI.GetComponent<Text>().text = timeOfDay;

			if(timeOfDay == "Morning")
			{
				camera.GetComponent<Camera>().backgroundColor = new Color(255.0f/255.0f,153.0f/255.0f,0.0f/255.0f);
			}
			else if(timeOfDay == "Day")
			{
				camera.GetComponent<Camera>().backgroundColor = new Color(0.0f/255.0f,171.0f/255.0f,255.0f/255.0f);
			}
			else if(timeOfDay == "Night")
			{
				camera.GetComponent<Camera>().backgroundColor = new Color(0.0f/255.0f,0.0f/255.0f,0.0f/255.0f);
			}
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

	public int getDay()
	{
		return day;
	}

	public string getFullTime()
	{
		return ("Time: " + hours + ":" + minutes);
	}
}
