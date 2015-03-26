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
	string message = "";
	string currentNode = "0";
	public bool taken = false;
	public bool isItem;
	//string speaker = "";
	
	void Start()
	{
		gameObject.AddComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		Twine =  GameObject.Find("TwineImporter").GetComponent<TwineImporter> ();
		Twine.ReadTwineFile(path);
		createMessage();
	}

	public void Progress(Inventory i)
	{
		/*Twine.TwineData.NextNode(currentNode);
		createMessage ();
		if (Twine.TwineData.Current.Link.Count != 0)
		{
			currentNode = Twine.TwineData.Current.Link[0];
		}*/
		Twine.TwineData.NextNode(currentNode);
		//Debug.Log (Twine.TwineData.Current.itemsReq);
		if (!Twine.TwineData.Current.itemsReq.Equals("")) 
		{
			Debug.Log("Item Required");
			if(i.inventory.Count!=0){
				for (int x=0; x < i.inventory.Count; x++) 
				{
					//Debug.Log(Twine.TwineData.Current.itemsReq.Contains(i.inventory[x]));
					if (Twine.TwineData.Current.itemsReq.Contains(i.inventory[x])) 
					{
						createMessage ();
						if (Twine.TwineData.Current.Link.Count != 0) 
						{
							//Debug.Log(Twine.TwineData.Current.Link [0]);
							currentNode = Twine.TwineData.Current.Link [0];
						}
						break;
					}	
				}
				
			}
		} 
		else 
		{
			//Debug.Log("No item required!");
			createMessage ();
			if (Twine.TwineData.Current.Link.Count != 0) 
			{
				//Debug.Log(Twine.TwineData.Current.Link [0]);
				currentNode = Twine.TwineData.Current.Link [0];
			}
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
				currentNode = "0";
				taken = true;

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
