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
	bool initalM_MapInactive = false;
	TimeManager timeManager;

	// Use this for initialization
	void Start () {
		//m_tack = transform.Find("Tack").gameObject;
		m_thumbnail = transform.Find("Box").gameObject;
		m_thumbnailButton = transform.Find("Travel Button").gameObject;
		m_map = GameObject.Find("Map_Level_1");
		mapUI = GameObject.FindGameObjectWithTag("MapUI");
		timeManager = ObjectFinder.FindOrCreateComponent<TimeManager>();
		active = false;
		m_thumbnail.SetActive(active);
		m_thumbnailButton.SetActive(active);
	}
	
	// Update is called once per frame
	void Update () {
		if(!initalM_MapInactive){
			m_map.SetActive(false);
			m_thumbnail.SetActive(false);
			m_thumbnailButton.SetActive(false);
			initalM_MapInactive = true;
		}
	}

	public void Travel()
	{
		active = false;
		m_map.SetActive (active);
		mapUI.SetActive(active);
		timeManager.passTime (30);
		Instantiate (m_levelToLoad);
	}

	public void ClickAction()
	{
		active = !active;

		foreach(GameObject tackUI in GameObject.FindGameObjectsWithTag("TackUI"))
		{
			tackUI.transform.parent.GetComponent<MarkerBhv>().active = false;
			tackUI.SetActive(false);
		}

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
