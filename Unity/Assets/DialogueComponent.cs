using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogueComponent : MonoBehaviour {
	TwineImporter twineImporter;
	public List<string> choicesList;
	public List<string> choicesLinksList;
	public List<string> choicesTitles;
	public bool choice = false;
	Inventory inventory;
	TimeManager timeManager;
	EmotionManager emotionManager;
	List<Interactable> backgroundInteractables;
	string message = "";
	string currentNode = "0";
	string toDisplay = "";
	public Image interactableImage;

	void Start()
	{
		Debug.Log("Startup called from dialogue component");
		choicesLinksList = new List<string> ();
		choicesList = new List<string> ();
		choicesTitles = new List<string>();
		twineImporter = ObjectFinder.FindOrCreateComponent<TwineImporter> ();
		inventory = ObjectFinder.FindOrCreateComponent<Inventory>();
		timeManager = ObjectFinder.FindOrCreateComponent<TimeManager>();
		emotionManager = ObjectFinder.FindOrCreateComponent<EmotionManager>();
		//set the interactable image to our Keymaster
		interactableImage.sprite = Interactable.KEYMASTER.avatarSpriteRenderer.sprite;
		//hide all interactables (de-activate)
		backgroundInteractables = new List<Interactable>();
		var interactables = GameObject.FindObjectsOfType<Interactable>();
		foreach(Interactable inter in interactables)
		{
			var parent = inter.transform.parent.gameObject;
			if(inter != null && inter != this  && parent.activeSelf)
			{
				inter.transform.parent.gameObject.SetActive(false);
				backgroundInteractables.Add(inter);
			}
		}
		
		twineImporter.ReadTwineFile(Interactable.KEYMASTER.path);
		createMessage();
	}
	
	public void Progress()
	{
		//first checks if the current node has choices or is linerally connected to another node
		if (!choice) 
		{
			//goes to the current node
			twineImporter.TwineData.NextNode (currentNode);
			//Debug.Log (Twine.TwineData.Current.itemsReq);
			
			//checks if there are any requirementes, item or emotion
			bool itemReq = !twineImporter.TwineData.Current.itemsReq.Equals ("");
			bool emotnReq = !twineImporter.TwineData.Current.EmotnReqChar.Equals( "");
			
			// if either exist, then check stuff before going to next node
			if (itemReq || emotnReq) 
			{
				//if there is an item requirement
				if(itemReq)
				{
					//if the player does not have the item, don't progress anymore
					if(!inventory.hasItem(twineImporter.TwineData.Current.itemsReq))
						return;
				}
				//if there is an emotion requirement
				if(emotnReq)
				{
					//if the player does not meet the requirement, do not progress
					if(!emotionManager.hasRequirement(twineImporter.TwineData.Current.EmotnReqChar,int.Parse(twineImporter.TwineData.Current.EmotnReqInt)))
						return;
				}
				//as long as the next node actually exists, move to the next node
				if (!twineImporter.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = twineImporter.TwineData.Current.Link [0];
				}
				//if there is no next node, exit the conversation
				else
				{
					OnDialogueCompelete();
				}
			}
			else 
			{
				createMessage ();
				//as long as the next node actually exists, move to the next node
				if (!twineImporter.TwineData.Current.Link[0].Equals( " ")) 
				{
					currentNode = twineImporter.TwineData.Current.Link [0];
					
				}
				//if there is no next node, exit the conversation
				else
				{
					OnDialogueCompelete();
				}
			}
		}
	}

	//Respond when a conversation is finished.
	void OnDialogueCompelete()
	{
		//if this is a person and you haven't already talked to them, move time forward an hour
		if(Interactable.KEYMASTER.isPerson && !Interactable.KEYMASTER.hasAlreadyTalked)
		{
			timeManager.passTime(60);
			Interactable.KEYMASTER.hasAlreadyTalked = true;
		}
		//re-activate interactables
		foreach(Interactable thing in backgroundInteractables)
		{
			thing.transform.parent.gameObject.SetActive(true);
		}
		backgroundInteractables.Clear();
		Interactable.KEYMASTER.selected = false;
		//RELEASE THE KEYMASTER now others can hold the power
		Interactable.KEYMASTER = null;
		Destroy(this.gameObject);
	}
	
	
	void Update()
	{
		if(twineImporter.TwineData == null)
			Debug.Log("There is no twine file loaded.");
		//adds item if current node calls for it
		if(twineImporter.TwineData.Current.ItemsGain !=""){
			inventory.addItem(twineImporter.TwineData.Current.ItemsGain);
		}
		//removes item if current node calls for it
		if(twineImporter.TwineData.Current.ItemRem !=""){
			inventory.removeItem(twineImporter.TwineData.Current.ItemRem);
		}
		//makes a character more unhappy if the current node calls for it
		if(twineImporter.TwineData.Current.EmotnDwn !=""){
			emotionManager.updateEmotions(twineImporter.TwineData.Current.EmotnDwn,false);
		}
		//makes a character happier if the current node calls for it
		if(twineImporter.TwineData.Current.EmotnUp !=""){
			emotionManager.updateEmotions(twineImporter.TwineData.Current.EmotnUp,true);
		}
		
		if(twineImporter.TwineData.Current.EndingFlag != "")
		{
			if(int.Parse(twineImporter.TwineData.Current.EndingFlag) == 1)
			{
				TimeManager.ending1Flag = true;
			}
			else if(int.Parse(twineImporter.TwineData.Current.EndingFlag)==2)
			{
				TimeManager.ending2Flag = true;
			}
		}
	}
	
	void OnGUI()
	{
		//if this interactable is currently selected
		if (Interactable.KEYMASTER.selected)
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
					twineImporter.TwineData.NextNode(currentNode);
					//Debug.Log(twineImporter.TwineData.Current.ContentData + "!");
					if(twineImporter.TwineData.Current.ContentData == "")
					{
						toDisplay = choicesTitles[i];
					}
					else{
						toDisplay = choicesList[i];
					}
					//if there is only one available choice, scale the button appropriately
					if(choicesLinksList.Count == 1)
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);
						
						if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,Screen.height/4*i,Screen.width - 10, Screen.height / choicesLinksList.Count / choicesLinksList.Count), toDisplay))
						{
							createMessage();
							currentNode = choicesList[i];
							twineImporter.TwineData.NextNode(currentNode);
							choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
							choicesTitles.Clear();
							
						}
					}
					//otherwise, scale per how many options
					else
					{
						GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);
						
						int yInc =  Screen.height / choicesLinksList.Count / choicesLinksList.Count;
						if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,(Screen.height - (yInc * (i+1))),Screen.width - 10,yInc), toDisplay))
						{
							createMessage();
							currentNode = choicesList[i];
							twineImporter.TwineData.NextNode(currentNode);
							choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
							choicesTitles.Clear();
						}
					}
				}
			}
			//if it is not a choice, show what is being said
			else
			{
				Rect rectangle = new Rect(Screen.width - (Screen.width - 5), 3 * (Screen.height / 4) - 5, Screen.width - 10, Screen.height / 4);
				if(GUI.Button(rectangle, message))
				{
					Progress();
				}
			}
		}
	}
	
	
	//build the dialog to be shown
	void createMessage()
	{
		//reset the emotion manager's booleans for the next node
		emotionManager.resetBooleans();
		message = "";
		
		//actually build the message
		foreach (char letter in twineImporter.TwineData.Current.ContentData.ToString())
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
		if (twineImporter.TwineData.Current.Link.Count == 1)
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
			tempNode = twineImporter.TwineData.Current;
			foreach (string currentChoice in twineImporter.TwineData.Current.Link)
			{
				bool triggered = false;
				twineImporter.TwineData.NextNode(currentChoice);
				bool itemReq = !twineImporter.TwineData.Current.itemsReq.Equals ("");
				bool emotnReq = !twineImporter.TwineData.Current.EmotnReqChar.Equals( "");
				if (itemReq || emotnReq) 
				{
					if(itemReq)
					{
						if(!inventory.hasItem(twineImporter.TwineData.Current.itemsReq))
							triggered = true;
					}
					if(emotnReq)
					{
						if(!emotionManager.hasRequirement(twineImporter.TwineData.Current.EmotnReqChar,int.Parse(twineImporter.TwineData.Current.EmotnReqInt)))
							triggered=true;
					}
					if (twineImporter.TwineData.Current.Link.Count != 0) 
					{
						currentNode = twineImporter.TwineData.Current.Link [0];
					}
				}
				if(!triggered)
				{
					choicesLinksList.Add(currentChoice);
					choicesList.Add(twineImporter.TwineData.Current.ContentData);
					choicesTitles.Add(twineImporter.TwineData.Current.LinkTitle[0]);
				}
			}
			twineImporter.TwineData.Current = tempNode;
		}
	}
}
