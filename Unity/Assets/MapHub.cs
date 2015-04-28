using UnityEngine;
using System.Collections;

public class MapHub : MonoBehaviour {
	GameObject lastLevelVisited;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject LastLevel
	{
		get{return lastLevelVisited;}
		set{lastLevelVisited = value;}
	}
}
