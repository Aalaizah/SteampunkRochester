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
	public Vector2 scrollPosition;
	public GUISkin backgroundUI;
	public GUISkin normal;
	public GameObject nameText;

	void Start()
	{
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
		//populate the dialogue with the initial twine node text
		createMessage();
	}
	
	public void Progress()
	{
		//first checks if the current node has choices or is linearly connected to another node
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
	public void OnDialogueCompelete()
	{
		//if this is a person and you haven't already talked to them, move time forward an hour
		if(Interactable.KEYMASTER.isPerson)
		{
			timeManager.passTime(60);
			Interactable.KEYMASTER.hasAlreadyTalked = true;
		}
		//re-activate interactables
		foreach(Interactable thing in backgroundInteractables)
		{
			thing.transform.parent.gameObject.SetActive(true);
		}
		if(Interactable.KEYMASTER.path.Contains("First"))
		{
			Interactable.KEYMASTER.path = Interactable.KEYMASTER.path.Replace("First","Generic");
		}
		backgroundInteractables.Clear();
		Interactable.KEYMASTER.selected = false;
		//RELEASE THE KEYMASTER now others can hold the power
		Interactable.KEYMASTER = null;
		Destroy(this.gameObject);
	}
	
	
	void Update()
	{
		Debug.Log(twineImporter.TwineData.Current.EmotnUp);
		nameText = GameObject.Find ("Name");
		if(nameText){
			
			nameText.GetComponent<Text>().text = Interactable.KEYMASTER.transform.parent.name;
		}

		if(twineImporter.TwineData == null)
		{
			Debug.Log("There is no twine file loaded.");
			if(String.IsNullOrEmpty(Interactable.KEYMASTER.path))
			{
				twineImporter.ReadTwineFile(Interactable.KEYMASTER.path);
			}
		}
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
			Debug.Log("Updating emotions!");
			emotionManager.updateEmotions(twineImporter.TwineData.Current.EmotnDwn,false);
		}
		//makes a character happier if the current node calls for it
		if(twineImporter.TwineData.Current.EmotnUp !=""){
			Debug.Log("Updating emotions!");
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
			
			//GUI.color = new Color(.9098f,.8275f,.0471f,1.0f);
			GUI.skin = backgroundUI;
			//if there is a choice currently
			if (choice)
			{
				//Dialouge ScrollBox
				Rect rectangle = new Rect(Screen.width - (Screen.width), 3 * (Screen.height / 4), Screen.width - 10, Screen.height / 4);
				
				GUILayout.BeginArea(rectangle);
				scrollPosition.y = Mathf.Infinity;
				scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(rectangle.width),GUILayout.Height(150));
				
				GUILayout.Box(message);
				
				GUILayout.EndScrollView();
				GUILayout.EndArea();
				
				//for every choice node, create a button for them
				for (int i = 0; i < choicesLinksList.Count; i++)
				{
					float choiceAreaHeight = (float)Screen.height * .5f;
					
					float choiceHeight =  choiceAreaHeight / choicesLinksList.Count;
					float x = Screen.width * (2/3) + Screen.width/4;
					float y = (float)(Screen.height * .25) + (choiceHeight * (i));

					currentNode = choicesLinksList[i];
					twineImporter.TwineData.NextNode(currentNode);
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
						//GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

						
						if (GUI.Button(new Rect(x,y,Screen.width/2,choiceHeight), toDisplay))
						{
							OnChoiceClick(i);
						}
					}
					//otherwise, scale per how many options
					else
					{
						//GUI.Box (new Rect(Screen.width - (Screen.width - 5),0,Screen.width - 10,Screen.height/4),message);

						
						if (GUI.Button(new Rect(x,y,Screen.width/2,choiceHeight), toDisplay))
						{
							OnChoiceClick(i);
						}
						
						
						/*
						if (GUI.Button(new Rect(Screen.width/2 - (Screen.width - 10)/2,((Screen.height/2) - (choiceHeight * (i+1))),Screen.width - 10,choiceHeight), toDisplay))
						{
							createMessage();
							currentNode = choicesList[i];
							Twine.TwineData.NextNode(currentNode);
							choice = false;
							choicesLinksList.Clear();
							choicesList.Clear();
							choicesTitles.Clear();
						}
*/
					}
				}
			}
			//if it is not a choice, show what is being said
			else
			{
				Rect rectangle = new Rect(Screen.width - (Screen.width), 3 * (Screen.height / 4), Screen.width - 10, Screen.height / 4);
				
				GUILayout.BeginArea(rectangle);
				scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(rectangle.width),GUILayout.Height(150));
				
				GUILayout.Box(message);
				
				if(GUI.Button(new Rect(rectangle.width - 125,scrollPosition.y + 5,100,50),"Progress"))
				{
					Progress();
					scrollPosition.y = Mathf.Infinity;
				}
				
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}

			GUI.skin = normal;
		}
	}

	void OnChoiceClick(int choiceIndex)
	{
		//createMessage();
		currentNode = choicesList[choiceIndex];
		twineImporter.TwineData.NextNode(currentNode);
		choice = false;
		choicesLinksList.Clear();
		choicesList.Clear();
		choicesTitles.Clear();
		Progress();
	}
	
	
	//build the dialog to be shown
	void createMessage()
	{
		//reset the emotion manager's booleans for the next node
		emotionManager.resetBooleans();
		message += "\n";

		message += twineImporter.TwineData.Current.Speaker[0] + ":";
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
