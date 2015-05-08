using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
	//used to lock out other interactables
	private static Interactable KEYMASTER;
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite hoverSprite;
    public Sprite activeSprite;
    public string id;
    public string path;
    public bool clicked;
    public bool selected;
	public bool isPerson;
	private bool hasAlreadyTalked = false;
    private bool readTwine;
    TwineImporter Twine;
    string message = "";
    string currentNode = "0";
    public bool taken = false;
    public List<string> choicesList;
    public List<string> choicesLinksList;
    public bool choice = false;
	Inventory inventory;
	TimeManager timeManager;
	EmotionManager emotionManager;
	public List<Interactable> otherInteractables;

    //string speaker = "";

    void Start()
    {
		Debug.Log (path);
		choicesLinksList = new List<string> ();
		choicesList = new List<string> ();
		otherInteractables = new List<Interactable> ();
        gameObject.AddComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
		Twine = GameObject.Find("TwineImporter").GetComponent<TwineImporter>();
		Twine.ReadTwineFile(path);
		inventory = GameObject.FindObjectOfType<Inventory>();
		timeManager = GameObject.FindObjectOfType<TimeManager>();
		emotionManager = GameObject.FindObjectOfType<EmotionManager>();
        createMessage();
    }

    public void Progress()
    {
		//first checks if the current node has choices or is linerally connected to another node
		if (!choice) 
		{
			//goes to the current node
			Twine.TwineData.NextNode (currentNode);
			//Debug.Log (Twine.TwineData.Current.itemsReq);

			//checks if there are any requirementes, item or emotion
			bool itemReq = !Twine.TwineData.Current.itemsReq.Equals ("");
			bool emotnReq = !Twine.TwineData.Current.EmotnReqChar.Equals( "");

			// if either exist, then check stuff before going to next node
			if (itemReq || emotnReq) 
			{
				//if there is an item requirement
				if(itemReq)
				{
					//if the player does not have the item, don't progress anymore
					if(!inventory.hasItem(Twine.TwineData.Current.itemsReq))
						return;
				}
				//if there is an emotion requirement
				if(emotnReq)
				{
					//if the player does not meet the requirement, do not progress
					if(!emotionManager.hasRequirement(Twine.TwineData.Current.EmotnReqChar,int.Parse(Twine.TwineData.Current.EmotnReqInt)))
						return;
				}
				//as long as the next node actually exists, move to the next node
				if (!Twine.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = Twine.TwineData.Current.Link [0];
				}
				//if there is no next node, exit the conversation
				else
				{
					selected = false;
				}
			}
			else 
			{
				createMessage ();
				//as long as the next node actually exists, move to the next node
				if (!Twine.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = Twine.TwineData.Current.Link [0];

				}
				//if there is no next node, exit the conversation
				else
				{
					selected = false;
				}
			}
    	}
	}


    void Update()
    {
		//adds item if current node calls for it
		if(Twine.TwineData.Current.ItemsGain !=""){
			inventory.addItem(Twine.TwineData.Current.ItemsGain);
		}
		//removes item if current node calls for it
		if(Twine.TwineData.Current.ItemRem !=""){
			inventory.removeItem(Twine.TwineData.Current.ItemRem);
		}
		//makes a character more unhappy if the current node calls for it
		if(Twine.TwineData.Current.EmotnDwn !=""){
			emotionManager.updateEmotions(Twine.TwineData.Current.EmotnDwn,false);
		}
		//makes a character happier if the current node calls for it
		if(Twine.TwineData.Current.EmotnUp !=""){
			emotionManager.updateEmotions(Twine.TwineData.Current.EmotnUp,true);
		}
		//if this is a person and you haven't already talked to them, move time forward an hour
		if(isPerson && !hasAlreadyTalked)
		{
			timeManager.passTime(60);
			hasAlreadyTalked = true;
		}
		//if the item is not currently selected, change the current node back to the origin
		if (!selected && currentNode != "0")
		{
			currentNode = "0";
			//release the keymaster role
			KEYMASTER = null;
			if(otherInteractables.Count > 0)
			{
				foreach(Interactable inter in otherInteractables)
				{
					inter.gameObject.SetActive(true);
				}
				otherInteractables.Clear();
			}
		}
    }

    void OnGUI()
    {
		//if this interactable is currently selected
        if (selected)
        {
            GUI.skin.box.wordWrap = true;
			GUI.skin.button.wordWrap = true;

			GUI.color = new Color(.9098f,.8275f,.0471f,1.0f);
			//if there is a choice currently
            if (choice)
            {
				//for every choice node, create a button for them
                for (int i = 0; i < choicesLinksList.Count; i++)
                {
					currentNode = choicesLinksList[i];
					Twine.TwineData.NextNode(currentNode);

					//if there is only one available choice, scale the button appropriately
					if(choicesLinksList.Count == 1)
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

	                    if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,Screen.height/4*i,Screen.width - 10, Screen.height / choicesLinksList.Count / choicesLinksList.Count), choicesList[i]))
	                    {
	                        createMessage();
							currentNode = choicesList[i];
	                        //Twine.TwineData.NextNode();
	                        choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
	                    }
					}
					//otherwise, scale per how many options
					else
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

						int yInc =  Screen.height / choicesLinksList.Count / choicesLinksList.Count;
						if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,(Screen.height - (yInc * (i+1))),Screen.width - 10,yInc), choicesList[i]))
						{
							createMessage();
							currentNode = choicesList[i];
							//Twine.TwineData.NextNode();
							choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
						}
					}
                }
            }
			//if it is not a choice, show what is being said
			else
			{
				GUI.Box(new Rect(Screen.width - (Screen.width - 5), 3 * (Screen.height / 4) - 5, Screen.width - 10, Screen.height / 4), message);
			}
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
		if(idleSprite)
        	spriteRenderer.sprite = idleSprite;
    }

	//when this is clicked
    void OnMouseDown()
    {
		//if it hasn't been clicked yet
        if (!clicked)
        {
			//All other interactables now must wait!
			var interactables = GameObject.FindObjectsOfType<Interactable>();
			foreach(Interactable inter in interactables)
			{
				if(inter != this)
				{
					inter.gameObject.SetActive(false);
					otherInteractables.Add(inter);
				}
			}
            clicked = true;
			//change the sprite if the active sprite exists
			if(activeSprite)
            	spriteRenderer.sprite = activeSprite;
			//selected gets changed (current active object
            selected = !selected;
			//Debug.Log(selected);
			//read the file amd set up nodes for conversation
			Twine.ReadTwineFile(path);
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


	//build the dialog to be shown
    void createMessage()
    {
		//reset the emotion manager's booleans for the next node
		emotionManager.resetBooleans();
        message = "";
		
		//actually build the message
        foreach (char letter in Twine.TwineData.Current.ContentData.ToString())
        {
            message += letter;
        }
		

        TypeText();
    }
	
	//???? is this even the correct name for what this does anymore?
    void TypeText()
    {
        TwineNode tempNode;

		//checks to see if there is a choice in the dialog
		//if no choice
        if (Twine.TwineData.Current.Link.Count == 1)
        {
            choice = false;
            //createMessage();
            //Twine.TwineData.NextNode(Twine.TwineData.Current.LinkData);
        }
		//otherwise
        else
        {
			//for each choice, make sure that the requirements are met before adding them into the list for buttons to be created
            choice = true;
            tempNode = Twine.TwineData.Current;
            foreach (string currentChoice in Twine.TwineData.Current.Link)
            {
				bool triggered = false;
				Twine.TwineData.NextNode(currentChoice);
				bool itemReq = !Twine.TwineData.Current.itemsReq.Equals ("");
				bool emotnReq = !Twine.TwineData.Current.EmotnReqChar.Equals( "");
				if (itemReq || emotnReq) 
				{
					if(itemReq)
					{
						if(!inventory.hasItem(Twine.TwineData.Current.itemsReq))
							triggered = true;
					}
					if(emotnReq)
					{
						if(!emotionManager.hasRequirement(Twine.TwineData.Current.EmotnReqChar,int.Parse(Twine.TwineData.Current.EmotnReqInt)))
							triggered=true;
					}
					if (Twine.TwineData.Current.Link.Count != 0) 
					{
						currentNode = Twine.TwineData.Current.Link [0];
					}
				}
                if(!triggered)
				{
                	choicesLinksList.Add(currentChoice);
                	choicesList.Add(Twine.TwineData.Current.ContentData);
				}
            }
            Twine.TwineData.Current = tempNode;
        }
    }
}
