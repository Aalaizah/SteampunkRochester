using UnityEngine;
using System.Collections;

public class MarkerBhv : MonoBehaviour {
	GameObject m_tack;
	GameObject m_thumbnail;
	GameObject m_map;
	MapHub mapScript;
	Vector2 m_mousePosition;
	public GameObject m_levelToLoad;

	// Use this for initialization
	void Start () {
		m_tack = transform.Find("Tack").gameObject;
		m_thumbnail = transform.Find("Thumbnail").gameObject;
		m_map = GameObject.Find("Map");
		mapScript = m_map.GetComponent<MapHub>();
	}
	
	// Update is called once per frame
	void Update () {
		m_mousePosition = Input.mousePosition;
		Camera cam = Camera.main;
		//convert the mouse to world coordinates
		Vector2 newMouse = cam.ScreenToWorldPoint(m_mousePosition);
		//check if the mouse contains
		if(m_tack.collider2D.bounds.Contains(newMouse))
		{
			m_thumbnail.SetActive(true);
			if(Input.GetMouseButtonDown(0))
			{
				//do something when tack is clicked
				ClickAction();
			}
		}else{
			m_thumbnail.SetActive(false);
		}
	}

	void ClickAction()
	{
		if(m_levelToLoad == null)
			return;
		//disable the map
		m_map.SetActive(false);
		//move time foward 30 minutes, if we werent just here
		Debug.Log("Time Ebbs: " + TimeManager.getFormattedTime());
		if(mapScript.LastLevel != m_levelToLoad)
		{
			TimeManager.passTime(30);
		}
		Debug.Log("Time and Flows?: " + TimeManager.getFormattedTime());
		mapScript.LastLevel = m_levelToLoad;
		//load level
		Instantiate(m_levelToLoad);
		Invoke("delayedChangeEvent", 1);
	}

	void delayedChangeEvent()
	{
		var obj = GameObject.FindObjectOfType<TestManager>();
		obj.SendMessage("OnLevelChange", m_map, SendMessageOptions.RequireReceiver);
	}
}
