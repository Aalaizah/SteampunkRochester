using UnityEngine;
using System.Collections;

public class MarkerBhv : MonoBehaviour {
	GameObject m_tack;
	GameObject m_thumbnail;
	GameObject m_thumbnailButton;
	public static GameObject m_map;
	public static GameObject mapUI;
	Vector2 m_mousePosition;
	public GameObject m_levelToLoad;
	bool active;
	TimeManager timeManager;

	// Use this for initialization
	void Start () {
		//m_tack = transform.Find("Tack").gameObject;
		m_thumbnail = transform.Find("Box").gameObject;
		m_thumbnailButton = transform.Find("Travel Button").gameObject;
		m_map = GameObject.Find("Map_Level_1");
		mapUI = GameObject.FindGameObjectWithTag("MapUI");
		timeManager = GameObject.FindObjectOfType<TimeManager>();
		active = false;
		m_thumbnail.SetActive(active);
		m_thumbnailButton.SetActive(active);

		//CHANGE LOCATION TEXT AND LOCATION IMAGE HERE
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Travel()
	{
		m_map.SetActive (false);
		mapUI.SetActive(false);
		timeManager.passTime (30);
		Instantiate (m_levelToLoad);
	}

	public void ClickAction()
	{
		active = !active;

		m_thumbnail.SetActive(active);
		m_thumbnailButton.SetActive(active);
		/*
		if(m_levelToLoad == null)
			return;
		//disable the map
		m_map.SetActive(false);
		//move time foward 30 minutes
		TimeManager.passTime(30);
		//load level
		Instantiate(m_levelToLoad);
		//todo, add player and disable map
		*/

	}
}
