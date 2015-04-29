using UnityEngine;
using System.Collections;

public class MarkerBhv : MonoBehaviour {
	GameObject m_tack;
	GameObject m_thumbnail;
	GameObject m_map;
	Vector2 m_mousePosition;
	public GameObject m_levelToLoad;

	// Use this for initialization
	void Start () {
		m_tack = transform.Find("Tack").gameObject;
		m_thumbnail = transform.Find("Thumbnail").gameObject;
		m_map = GameObject.Find("Map_BG");
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
		//move time foward 30 minutes
		TimeManager.passTime(30);
		//load level
		Instantiate(m_levelToLoad);
		//todo, add player and disable map
	}
}
