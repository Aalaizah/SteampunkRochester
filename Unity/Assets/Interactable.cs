using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour {
	
	private SpriteRenderer spriteRenderer;
	public Sprite idleSprite;
	public Sprite hoverSprite;
	public Sprite activeSprite;
	public string id;
	public string path;
	private bool clicked;
	public bool selected;
	private bool readTwine;
	TwineImporter Twine;
	public List<string> contentList;
	string message = "";
	int currentNode = 0;
	//string speaker = "";
	
	void Start()
	{
		gameObject.AddComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		Twine =  GameObject.Find("TwineImporter").GetComponent<TwineImporter> ();
		Twine.ReadTwineFile(path);
		createMessage();
	}

	public void Progress()
	{
		currentNode++;
		if (currentNode < Twine.twineDataList.Count) {
			Twine.TwineData.NextNode (currentNode.ToString ());
			createMessage ();
		} 
	}

	void Update()
	{
		
	}

	void OnGUI() {
		if(selected)
		{
			GUI.skin.box.wordWrap = true;
			GUI.Box (new Rect (Screen.width - (Screen.width - 5), 3 * (Screen.height / 4) - 5, Screen.width - 10, Screen.height / 4),message);
		}
	}
	
	void OnMouseOver()
	{
		if(!clicked)
		{
			spriteRenderer.sprite = hoverSprite;
		}
	}
	
	void OnMouseExit()
	{
		clicked = false;
		spriteRenderer.sprite = idleSprite;
	}
	
	void OnMouseDown()
	{
		if(!clicked)
		{

			clicked = true;
			spriteRenderer.sprite = activeSprite;
			selected = !selected;
			Debug.Log(selected);
			if(!selected){
				currentNode = -1;

			}
		}
	}
	
	void OnMouseUp()
	{
		clicked = false;
	}
	
	public void SetName(string pName,string pPath)
	{
		id = pName;
		path = pPath;
		spriteRenderer = GetComponent<SpriteRenderer>();

		idleSprite = Resources.Load<Sprite>(id + "Idle");
		hoverSprite = Resources.Load<Sprite>(id + "Hover");
		activeSprite = Resources.Load<Sprite>(id + "Active");
		
		spriteRenderer.sprite = idleSprite;
	}

	void createMessage()
	{
		message = "";
		
		//speaker = Twine.TwineData.Current.SpeakerData;

		foreach (char letter in Twine.TwineData.Current.ContentData.ToString()) 
		{
			message += letter;
			//yield return new WaitForSeconds (letterPause);
		}
		
		//contentList.Clear();
	}
}
