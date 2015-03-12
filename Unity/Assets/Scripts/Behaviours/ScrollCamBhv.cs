using UnityEngine;
using System.Collections;

public class ScrollCamBhv : MonoBehaviour {
	public float m_scrollSpeed;
	public float m_scrollWidth;
	public float m_scrollHeight;
	Camera m_camera;

	// Use this for initialization
	void Start () {
		refreshCamera();
	}
	
	// Update is called once per frame
	void Update () {
		refreshCamera();
		clamp();
	}

	public void Scroll(bool a_right, bool a_left, bool a_up, bool a_down)
	{
		Vector2 movement = Vector2.zero;
		if(a_right)
			movement.x += m_scrollSpeed;
		if(a_left)
			movement.x -= m_scrollSpeed;
		if(a_up)
			movement.y += m_scrollSpeed;
		if(a_down)
			movement.y -= m_scrollSpeed;
		m_camera.transform.Translate(movement);
		Debug.Log("Cam Pos: " + m_camera.transform.position);
	}

	void clamp()
	{
		Vector3 camPos = m_camera.transform.position;
		float left = -m_scrollWidth;
		float right = m_scrollWidth;
		float top = m_scrollHeight;
		float bottom = -m_scrollHeight;
		if(camPos.x < left)
			camPos.x = left;
		if(camPos.x > right)
			camPos.x = right;
		if(camPos.y < bottom)
			camPos.y = bottom;
		if(camPos.y > top)
			camPos.y = top;
		m_camera.transform.position = camPos;
	}

	void refreshCamera()
	{
		m_camera = Camera.main;
		if(m_camera==null)
			throw new UnassignedReferenceException("Scroll camera reference is null.");
	}
}
