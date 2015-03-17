using UnityEngine;
using System.Collections;

public class ScrollCamBhv : MonoBehaviour {
	float m_constantScale = 100;
	public float m_scrollSpeed;
	public float m_scrollWidth;
	public float m_scrollHeight;
	public bool m_inclusive;
	Camera m_camera;
	
	void clamp()
	{
		Vector3 camPos = m_camera.transform.position;
		float halfWidth = m_scrollWidth / 2 / m_constantScale;
		float halfHeight = m_scrollHeight / 2 / m_constantScale;
		float padding = 0;
		float aspectRatio = Camera.main.aspect;
		//add padding to the boundaries
		if (m_inclusive)
			padding = Camera.main.orthographicSize;
		float left = -halfWidth + padding * aspectRatio;
		float right = halfWidth - padding * aspectRatio;
		float top = halfHeight - padding;
		float bottom = -halfHeight + padding;
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
	
	// Use this for initialization
	void Start () {
		refreshCamera();
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
		m_camera.transform.Translate(movement/m_constantScale);
	}
	
	// Update is called once per frame
	void Update () {
		refreshCamera();
		clamp();
	}
}
