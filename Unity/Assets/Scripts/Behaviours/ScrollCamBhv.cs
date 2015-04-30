using UnityEngine;
using System.Collections;

public class ScrollCamBhv : MonoBehaviour {
	float m_constantScale = 100;
	public float m_scrollSpeed;
	float m_scrollWidth;
	float m_scrollHeight;
	public bool m_inclusive;
	public bool enableVerticalScroll;
	public bool fitVertically;
	public Bounds bounds;
	public Vector2 center;
	Camera m_camera;
	SpriteRenderer background;
	
	void clamp()
	{
		Vector3 camPos = m_camera.transform.localPosition;
		float halfWidth = m_scrollWidth / 2 / m_constantScale;
		float halfHeight = m_scrollHeight / 2 / m_constantScale;
		Vector2 padding = Vector2.zero;
		float aspectRatio = m_camera.aspect;
		//add padding to the boundaries
		if (m_inclusive)
		{
			float ortho = m_camera.orthographicSize;
			padding = new Vector2(ortho * aspectRatio, ortho);
		}
		//apply all sorts of crap so we are in the right frame of reference
		float left = Mathf.Min(0, background.sprite.bounds.min.x + padding.x) + center.x;
		float right = Mathf.Max(0, background.sprite.bounds.max.x - padding.x) + center.x;
		float top = Mathf.Min(0, background.sprite.bounds.min.y + padding.y) + center.y;
		float bottom = Mathf.Max(0, background.sprite.bounds.max.y - padding.y) + center.y;
		bounds = background.sprite.bounds;
		camPos.x = Mathf.Clamp (camPos.x, left, right);
		if (enableVerticalScroll) {
			camPos.y = Mathf.Clamp (camPos.y, top, bottom);
		}
		m_camera.transform.localPosition = camPos;
	}
	
	void refreshCamera()
	{
		m_camera = Camera.main;
		if (m_camera == null) {
			throw new UnityException("Scroll camera reference is null.");
		}
		if (fitVertically) {
			//Debug.Log("Do we even have bounds?" + background.sprite);
			//m_camera.orthographicSize = background.sprite.bounds.extents.y;
		}
	}
	
	// Use this for initialization
	void Start () {
		refreshCamera();
		//find the background so we can clamp to it
		var bg = GameObject.Find ("Bg");
		if (bg == null)
			throw new UnityException ("Either the level doesnt have a background. Or the background is not named \"Bg\"");
		background = bg.GetComponent<SpriteRenderer> ();
		var tex = background.sprite.texture;
		var scale = background.transform.localScale;
		m_scrollWidth = (float)tex.width * scale.x;
		m_scrollHeight = (float)tex.height * scale.y;
		center = bg.transform.localPosition;
		//dark magics
		//Camera.main.orthographicSize = (m_scrollHeight / m_constantScale) * 2;
	}

	public void Scroll(bool a_right, bool a_left, bool a_up, bool a_down)
	{
		Vector2 movement = Vector2.zero;
		if(a_right)
			movement.x += m_scrollSpeed;
		if(a_left)
			movement.x -= m_scrollSpeed;
		if (enableVerticalScroll) {
			if (a_up)
				movement.y += m_scrollSpeed;
			if (a_down)
				movement.y -= m_scrollSpeed;
		}
		m_camera.transform.Translate(movement/m_constantScale);
	}
	
	// Update is called once per frame
	void Update () {
		refreshCamera();
	}

	void LateUpdate()
	{
		clamp();
	}
}
