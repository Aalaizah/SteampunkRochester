using UnityEngine;
using System.Collections;

public class ScrollCamCtrl : MonoBehaviour {
	ScrollCamBhv m_scrollBhv;
	Vector2 m_mousePos;
	public float m_padding = 25;
	
	void OnGUI(){
		//create rectangles to indicate scroll regions
		//Adapt these to the screens resolution
		float innerBot = Screen.height - m_padding;
		float innerRight = Screen.width - m_padding;
		Rect topBar = new Rect (0, 0, Screen.width, m_padding);
		Rect bottomBar = new Rect (0, innerBot, Screen.width, m_padding);
		Rect leftBar = new Rect (0, m_padding, m_padding, innerBot - m_padding);
		Rect rightBar = new Rect (innerRight, m_padding, m_padding, innerBot - m_padding);
		//draw these rectangles as boxes
		GUI.Box (topBar, string.Empty);
		GUI.Box (bottomBar, string.Empty);
		GUI.Box (leftBar, string.Empty);
		GUI.Box (rightBar, string.Empty);
	}

	// Use this for initialization
	void Start () {
		m_scrollBhv = gameObject.GetComponent<ScrollCamBhv>();
	}
	
	// Update is called once per frame
	void Update () {
		updateMouse();
		moveByInput();

	}

	void updateMouse()
	{
		//update current to present
		m_mousePos = Input.mousePosition;
	}

	void moveByInput()
	{
		//scroll based on mouse movement (wrong)
		float width = Screen.width;
		float height = Screen.height;
		float left = m_padding;
		float right = width - m_padding;
		float bottom = m_padding;
		float top = height - m_padding;
		bool west = m_mousePos.x < left;
		bool east = m_mousePos.x > right;
		bool north = m_mousePos.y > top;
		bool south = m_mousePos.y < bottom;
		m_scrollBhv.Scroll(east, west, north, south);
	}
}