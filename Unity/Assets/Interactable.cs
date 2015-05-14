using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
	public static Interactable KEYMASTER;
	public SpriteRenderer avatarSpriteRenderer{get;protected set;}
	private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite hoverSprite;
    public Sprite activeSprite;
    public string id;
    public string path;
    public bool clicked;
    public bool selected;
	public bool isPerson;
	public bool hasAlreadyTalked = false;
    private bool readTwine;
	public string itemToGain;
    TwineImporter Twine;
    public bool taken = false;
	public bool isFinalEditor = false;
	Inventory inventory;
	TimeManager timeManager;
	EmotionManager emotionManager;

    //string speaker = "";

    void Start()
    {
		if(isFinalEditor)
		{
			if(TimeManager.ending1Flag)
			{
				path = "Ending3";
			}
			else if(TimeManager.ending2Flag)
			{
				path = "Ending1";
			}
			else{
				path = "Ending2";
			}
		}
		
        gameObject.AddComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

		inventory = ObjectFinder.FindOrCreateComponent<Inventory>();
		timeManager = ObjectFinder.FindOrCreateComponent<TimeManager>();
		emotionManager = ObjectFinder.FindOrCreateComponent<EmotionManager>();
		spriteRenderer.sprite = null;

		//find our parent (avatar) spriteRenderer so we can display it on dialogue screen
		var parent = transform.parent;
		if(parent != null)
		{
			avatarSpriteRenderer = parent.GetComponent<SpriteRenderer>();
		}
    }

	//when the mouse hovers
    void OnMouseOver()
    {
		//if it hasn't been clicked
        if (!clicked)
        {
			//if the hoversprite exists, change the sprite
			if(hoverSprite)
            	spriteRenderer.sprite = hoverSprite;
        }
    }

	//when the mouse no longer hovers over the object/person
    void OnMouseExit()
    {
		//change clicked to false and the idle sprite is now active if they have it
        clicked = false;
       	spriteRenderer.sprite = null;
    }

	//when this is clicked
    void OnMouseDown()
    {
		//if it hasn't been clicked yet
        if (!clicked)
        {
            clicked = true;
			//change the sprite if the active sprite exists
			if(activeSprite)
            	spriteRenderer.sprite = activeSprite;
			//selected gets changed (current active object
            selected = !selected;
			KEYMASTER = this;
			//create a new dialogue screen and give it the interactable
			var dialogue = Resources.Load<GameObject>("Prefabs/DialogueScreen");
			Instantiate(dialogue);
        }
		
		//if this is a person and you haven't already talked to them, move time forward an hour
		if(isPerson && !hasAlreadyTalked)
		{
			timeManager.passTime(60);
			hasAlreadyTalked = true;
		}
    }
	//after the click finishes
    void OnMouseUp()
    {
		clicked = false;
    }
	//set the name of the item
    public void SetName(string pName, string pPath)
    {
        id = pName;
        path = pPath;
        spriteRenderer = GetComponent<SpriteRenderer>();

        idleSprite = Resources.Load<Sprite>(id + "Idle");
        hoverSprite = Resources.Load<Sprite>(id + "Hover");
        activeSprite = Resources.Load<Sprite>(id + "Active");

        spriteRenderer.sprite = idleSprite;
    }
}
