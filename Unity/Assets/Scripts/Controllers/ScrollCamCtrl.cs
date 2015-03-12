using UnityEngine;
using System.Collections;

public class ScrollCamCtrl : MonoBehaviour {
	ScrollCamBhv m_scrollBhv;
	Vector2 m_mousePos;
	Vector2 m_mousePosOld;
	Vector2 m_mouseChange;
	public float padding;

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
		//set old mouse to current
		m_mousePosOld = m_mousePos;
		//update current to present
		m_mousePos = Input.mousePosition;
		//get vector to current from old
		m_mouseChange = m_mousePos - m_mousePosOld;
	}

	void moveByInput()
	{
		//scroll based on mouse movement (wrong)
		float width = Screen.width;
		float height = Screen.height;
		float left = padding;
		float right = width - padding;
		float bottom = padding;
		float top = height - padding;
		bool west = m_mousePos.x < left;
		bool east = m_mousePos.x > right;
		bool north = m_mousePos.y > top;
		bool south = m_mousePos.y < bottom;
		m_scrollBhv.Scroll(east, west, north, south);
	}
}