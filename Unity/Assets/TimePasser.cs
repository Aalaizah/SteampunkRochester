using UnityEngine;
using System.Collections;

public class TimePasser : MonoBehaviour {
	TimeManager time;
	// Use this for initialization
	void Start () {
		time = ObjectFinder.FindOrCreateComponent<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Forward()
	{
		time.passTime(-60);
	}

	public void Backward()
	{
		time.passTime(60);
	}
}
