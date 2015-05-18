using UnityEngine;
using System.Collections;

public class ScrollCamCtrl : MonoBehaviour {
	ScrollCamBhv m_scrollBhv;
	Vector2 m_mousePos;
	public float m_padding = 25;
	public float arrowNormalOpacity = 0.2f;
	public float arrowHoverOpacity = 0.8f;
	SpriteRenderer arrowRight;
	SpriteRenderer arrowLeft;

	// Use this for initialization
	void Start () {
		m_scrollBhv = gameObject.GetComponent<ScrollCamBhv>();
		//find the arrows so we don't have to find them in the levelEditor scene
		var arrowR = transform.FindChild ("arrowRight").gameObject;
		var arrowL = transform.FindChild ("arrowLeft").gameObject;
		arrowRight = arrowR.GetComponent<SpriteRenderer> ();
		arrowLeft = arrowL.GetComponent<SpriteRenderer> ();
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
		Color normal = new Color (1.0f, 1.0f, 1.0f, arrowNormalOpacity);
		Color hover = new Color (1.0f, 1.0f, 1.0f, arrowHoverOpacity);
		if (east) {
			arrowRight.color = hover;
		} else {
			arrowRight.color = normal;
				}
		if (west) {
			arrowLeft.color = hover;
		} else {
			arrowLeft.color = normal;
				}
		m_scrollBhv.Scroll(east, west, north, south);
	}
}